using Autofac;
using ShoppingBasketDataService.Classes;
using ShoppingBasketDataService.Interfaces;
using ShoppingBasketUi.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShoppingBasketUi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {       
        public static IContainer Container { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FetchDataService>().As<IFetchDataService>();
            builder.RegisterType<MainWindow>().As<MainWindow>();
            Container = builder.Build();            
            using (var scope = Container.BeginLifetimeScope())
            {
                var fetchDataService = scope.Resolve<IFetchDataService>();
                var productsData = fetchDataService.GetProducts();
                var specialOffers = fetchDataService.GetSpecialOffers(productsData);
                var mainViewModel = new MainViewModel(productsData, specialOffers);                
                var window = scope.Resolve<MainWindow>(new TypedParameter(typeof(MainViewModel),mainViewModel));
                window.Show();
            }
        }
    }
}
