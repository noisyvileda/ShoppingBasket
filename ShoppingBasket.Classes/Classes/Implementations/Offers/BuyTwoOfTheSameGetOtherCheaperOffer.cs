using ShoppingBasket.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Classes.Classes.Implementations.Offers
{
    public class BuyTwoOfTheSameGetOtherCheaperOffer : ISpecialOffer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IProduct> ProductsAppliedTo { get; set; }        
        public decimal Discount { get; set; }
        public decimal CalculatedDiscount { get; set; }

        public void CalculateSpecialOffer(IEnumerable<IProduct> products)
        {
            CalculatedDiscount = 0.0m;
            if (IsEnabled(products))
            {
                var discountedProducts = products.Where(x => x.GetType() == ProductsAppliedTo.Last().GetType());
                var timesDiscountCanBeMade = products.Where(x => x.GetType() == ProductsAppliedTo.First().GetType()).Count() / 2;
                var discountedProductCount = discountedProducts.Count();
                for(int i = 0; i < discountedProductCount; i++)
                {
                    if(i < timesDiscountCanBeMade)
                    {
                        CalculatedDiscount += (discountedProducts.First().Price * Discount) / 100;
                    }
                }
            }
        }

        public bool IsEnabled(IEnumerable<IProduct> products)
        {
            if(products.Where(x => x.GetType() == ProductsAppliedTo.First().GetType()).Count() >= 2 && products.Where(x => x.GetType() == ProductsAppliedTo.Last().GetType()).Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
