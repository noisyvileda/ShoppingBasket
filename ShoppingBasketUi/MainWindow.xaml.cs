using Autofac;
using ShoppingBasketDataService.Interfaces;
using ShoppingBasketUi.Classes;
using ShoppingBasketUi.UI;
using ShoppingBasketUi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShoppingBasketUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel mainViewModel;
        public MainWindow()
        {
            InitializeComponent();            
        }
        public MainWindow(MainViewModel mainviewmodel)
        {
            mainViewModel = mainviewmodel;
            InitializeComponent();
            ChangeHandler.RegisterWindow(this);
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(var product in mainViewModel.Products)
            {
                productstack.Children.Add(new Product(mainViewModel, product));
            }
        }
    }
}
