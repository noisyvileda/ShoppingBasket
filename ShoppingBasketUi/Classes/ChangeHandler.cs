using ShoppingBasketUi.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketUi.Classes
{
    internal  static class ChangeHandler
    {
        private static MainWindow MainWindow;
        public static void RegisterWindow(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }
        public static void DisplayBasket()
        {
            App.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                MainWindow.BasketStack.Children.Clear();
                foreach (var product in MainWindow.mainViewModel.ShoppingBasket.Products)
                {
                    MainWindow.BasketStack.Children.Add(new Product(MainWindow.mainViewModel, product) { IsBasket = true });
                }
                MainWindow.SummaryText.Text = MainWindow.mainViewModel.ShoppingBasket.Summary();
            }));            
        }
    }
}
