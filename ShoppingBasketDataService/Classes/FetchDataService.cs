using ShoppingBasket.Classes.Classes.Factories;
using ShoppingBasket.Models.Interfaces;
using ShoppingBasket.SQLService;
using ShoppingBasketDataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDataService.Classes
{
    public class FetchDataService : IFetchDataService
    {

        public IEnumerable<IProduct> GetProducts()
        {
            List<IProduct> products = new List<IProduct>();
            var productFactory = new ProductFactory();
            DataHandler dataHandler = new DataHandler();
            var ds = dataHandler.GetProductDataSet();
            foreach (System.Data.DataRow product in ds.Tables[0].Rows)
            {
                products.Add(productFactory.GetProduct(product.ItemArray));
            }
            return products;
        }

        public IEnumerable<ISpecialOffer> GetSpecialOffers(IEnumerable<IProduct> products)
        {
            var discountFactory = new DiscountFactory(products);            
            DataHandler dataHandler = new DataHandler();
            var ds = dataHandler.GetOffersDataSet();
            List<ISpecialOffer> specialOffers = new List<ISpecialOffer>();
            foreach (System.Data.DataRow product in ds.Tables[0].Rows)
            {
                specialOffers.Add(discountFactory.GetSpecialOffer(product.ItemArray));                
            }
            return specialOffers;
        }
     
    }
}
