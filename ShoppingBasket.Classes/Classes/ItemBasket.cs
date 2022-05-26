using ShoppingBasket.Models;
using ShoppingBasket.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Classes.Classes
{
    public class ItemBasket
    {
        private List<IProduct> products;
        public ItemBasket()
        {
            products = new List<IProduct>();
        }
        public void AddProduct(IProduct product)
        {
            products.Add(product);
        }
        public void RemoveProduct(IProduct product)
        {
            products.Remove(product);
        }
    }
}
