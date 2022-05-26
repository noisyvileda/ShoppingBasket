using ShoppingBasket.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Models.Classes.Implementations
{
    public class Basket
    {
        public IEnumerable<ISpecialOffer> SpecialOffers;
        public List<IProduct> Products;
        public Basket(IEnumerable<ISpecialOffer> specialOffers)
        {
            SpecialOffers = specialOffers;
            Products = new List<IProduct>();
        }
        public void AddProduct(IProduct product)
        {
            Products.Add(product);            
        }
        public void RemoveProduct(IProduct product)
        {
            Products.Remove(product);            
        }
        public decimal CalculateSubTotal()
        {
            decimal subTotal = 0m;
            foreach (var product in Products)
            {
                subTotal += product.Price;
            }
            return subTotal;
        }
        public void CalculateTotalDiscount()
        {
            foreach (var discountOffer in SpecialOffers)
            {
                discountOffer.CalculateSpecialOffer(Products);
            }
        }
        public string Summary()
        {
            CalculateTotalDiscount();

            StringBuilder result = new StringBuilder();
            result.Append("----------" + Environment.NewLine);
            var groupings = Products.GroupBy(x => x.Id);
            foreach (var grouping in groupings)
            {
                var groupingPrice = 0m;
                groupingPrice = grouping.Sum(x => x.Price);
                result.Append($"{grouping.FirstOrDefault().Name} x {grouping.Count()} : {groupingPrice} $" + Environment.NewLine);
            }
            var SubTotal = CalculateSubTotal();
            var discountPrice = 0m;
            result.Append($"Subtotal : {SubTotal} $" + Environment.NewLine);
            foreach (var offer in SpecialOffers)
            {
                if (offer.IsEnabled(Products))
                {
                    discountPrice += offer.CalculatedDiscount;
                    result.Append($"Discount active {offer.Name} : {offer.CalculatedDiscount}$" + Environment.NewLine);
                }
            }
            result.Append($"Total : {SubTotal - discountPrice}");
            return result.ToString();
        }
    }
}
