using ShoppingBasket.Models.Interfaces;
using ShoppingBasketUi.Classes;
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

namespace ShoppingBasketUi.UI
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : UserControl
    {
        private MainViewModel mainViewModel;
        private IProduct product;
        public string ProductDescriptionText { get; set; }

        public bool IsBasket { get; set; }
        public Product(MainViewModel mainviewmodel, IProduct product)
        {
            this.mainViewModel = mainviewmodel;
            this.product = product;
            ProductDescriptionText = product.ToString();          
            this.Loaded += Product_Loaded;
            InitializeComponent();
        }

        private void Product_Loaded(object sender, RoutedEventArgs e)
        {
            this.ProductDescription.Text = ProductDescriptionText;
            this.Addbuton.Foreground = Brushes.WhiteSmoke;
            if (IsBasket)
            {
                this.Addbuton.Background = Brushes.Tomato;
                this.Addbuton.Content = "Remove Item";
            }
            else
            {
                this.Addbuton.Background = Brushes.LawnGreen;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!IsBasket)
            {
                mainViewModel.ShoppingBasket.AddProduct(product);
                ChangeHandler.DisplayBasket();
            }
            else
            {
                mainViewModel.ShoppingBasket.RemoveProduct(product);
                ChangeHandler.DisplayBasket();
            }
        }
    }
}
