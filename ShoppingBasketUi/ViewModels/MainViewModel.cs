using ShoppingBasket.Models.Interfaces;
using ShoppingBasketUi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketUi.ViewModels
{
    public class MainViewModel
    {
        public IEnumerable<IProduct> Products;
        public IEnumerable<ISpecialOffer> SpecialOffers;
        public Basket ShoppingBasket; 
        public MainViewModel(IEnumerable<IProduct> products, IEnumerable<ISpecialOffer> specialOffers)
        {
            Products = products;
            SpecialOffers = specialOffers;
            ShoppingBasket = new Basket(specialOffers);
        }
    }
}
