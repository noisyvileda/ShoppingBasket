using ShoppingBasket.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Classes.Classes.Implementations.Offers
{
    public class WeekOffer : ISpecialOffer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WeekAppliesTo { get; set; }
        public IEnumerable<IProduct> ProductsAppliedTo { get; set; }
        public decimal Discount { get; set; }
        public decimal CalculatedDiscount { get; set; }

        public void CalculateSpecialOffer(IEnumerable<IProduct> products)
        {
            CalculatedDiscount = 0.0m;
            foreach (var product in products)
            {
                if (ProductsAppliedTo.Any(x => x.GetType() == product.GetType() && x.Name == product.Name))
                {
                    foreach (var discountedProduct in products.Where(x => x.GetType() == product.GetType() && x.Name == product.Name))
                    {
                        CalculatedDiscount += (discountedProduct.Price * Discount) / 100;
                    }
                }
            }
        }      

        public bool IsEnabled(IEnumerable<IProduct> products)
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            Calendar calendar = culture.Calendar;
            int currentWeek = calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return currentWeek == WeekAppliesTo;
        }
      
    }
}
