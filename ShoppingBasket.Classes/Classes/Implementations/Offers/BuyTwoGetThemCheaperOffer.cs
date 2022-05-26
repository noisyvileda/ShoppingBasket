using ShoppingBasket.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Classes.Classes.Implementations.Offers
{
    public class BuyTwoGetThemCheaperOffer : ISpecialOffer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IProduct> ProductsAppliedTo { get; set; }
        public decimal Discount { get; set; }
        public decimal CalculatedDiscount { get; set; }        

        public void CalculateSpecialOffer(IEnumerable<IProduct> products)
        {
            CalculatedDiscount = 0.0m;
            if(IsEnabled(products))
            {
                var discountedProductPairs = new List<Tuple<string, int>>();
                foreach (var productApplied in ProductsAppliedTo)
                {
                    discountedProductPairs.Add(new Tuple<string, int>(productApplied.GetType().ToString(), products.Where(x => x.GetType() == productApplied.GetType()).Count()));
                }
                var minValue = discountedProductPairs.Select(x => x.Item2).Min();
                foreach (var productApplied in ProductsAppliedTo)
                {
                    var discountedItems = products.Where(x => x.GetType() == productApplied.GetType()).OrderByDescending(x => x.Price).Reverse().Take(minValue);
                    foreach (var discountedItem in discountedItems)
                    {
                        CalculatedDiscount += (discountedItem.Price * Discount) / 100;
                    }
                }
            }            
        }
      
        public bool IsEnabled(IEnumerable<IProduct> products)
        {
            bool result = true;
            foreach (var productApplied in ProductsAppliedTo)
            {
                if (!products.Any(x => x.GetType() == productApplied.GetType() && x.Name == productApplied.Name))
                {
                    result = false;
                }
            }
            return result;
        }
       
    }
}
