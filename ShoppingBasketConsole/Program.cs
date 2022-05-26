using ShoppingBasket.Classes.Classes.Factories;
using ShoppingBasket.SQLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            var fact = new ProductFactory();
            //var products = fact.ReturnProducts();       
           // var offer = new DiscountFactory();
           // var discounts = offer.ReturnSpecialOffers();
           // products.Add(fact.GetProduct("Soup"));

            //discounts.Last().CalculateSpecialOffer(products);
            DataHandler dh = new DataHandler();
            var ds = dh.GetProductDataSet();
            foreach(System.Data.DataRow product in ds.Tables[0].Rows)
            {
                var sqlProduct = fact.GetProduct(product.ItemArray);
            }

            Console.ReadLine();
        }
    }
}
