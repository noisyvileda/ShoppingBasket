using ShoppingBasket.Classes.Classes.Implementations.Offers;
using ShoppingBasket.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Classes.Classes.Factories
{
    public class DiscountFactory
    {
        private readonly IEnumerable<IProduct> _products;
        public DiscountFactory(IEnumerable<IProduct> products)
        {
            _products = products;
        }
        public List<ISpecialOffer> ReturnSpecialOffers()
        {
            ProductFactory productFactory = new ProductFactory();
            var products = productFactory.ReturnProducts();
            List<ISpecialOffer> specialOffers = new List<ISpecialOffer>();
            var prodListOffer = new List<IProduct>() { products.Where(x => x.Name == "Bread").First(), products.Where(x => x.Name.Contains("Milk")).First() };
            var prodListOffer2 = new List<IProduct>() { products.Where(x => x.Name == "Soup").First(), products.Where(x => x.Name.Contains("Roll")).First() };
            specialOffers.Add(new WeekOffer() { Name = "Apples 10% off in current week", ProductsAppliedTo = products.Where(x => x.Name == "Apples").ToList(), Discount = 10m, WeekAppliesTo = 20 });
            specialOffers.Add(new BuyTwoGetThemCheaperOffer() { Name = "Buy any bread and milk, get them cheaper offer", ProductsAppliedTo = prodListOffer, Discount = 20m });
            specialOffers.Add(new BuyTwoOfTheSameGetOtherCheaperOffer() { Name = "Buy two Soups, get one roll for cheaper", ProductsAppliedTo = prodListOffer2, Discount = 50m });
            return specialOffers;
        }      
        public ISpecialOffer GetSpecialOffer(object[] itemArray)
        {
            if (itemArray.Length > 0)
            {
                int id = int.Parse(itemArray[0].ToString());
                decimal discount = decimal.Parse(itemArray[1].ToString());
                string affectedProductString = itemArray[2].ToString().Trim();
                var iProducts = new List<IProduct>();
                string[] affectedItems = affectedProductString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (affectedItems.Length > 0)
                {
                    for (int i = 0; i < affectedItems.Length; i++)
                    {
                        if (_products.Any(x => x.Id == int.Parse(affectedItems[i])))
                        {
                            iProducts.Add(_products.First(x => x.Id == int.Parse(affectedItems[i])));
                        }
                    }
                }
                string name = itemArray[3].ToString().Trim();
                string discountType = itemArray[4].ToString().Trim();
                string additionalPlaceHolderString = itemArray[5].ToString().Trim();
                switch (discountType)
                {
                    case "WeekOffer":
                        return GetWeekOffer(id, name, iProducts, discount, int.Parse(additionalPlaceHolderString));
                    case "BuyTwoGetThemCheaperOffer":
                        return GetBuyTwoGetThemCheaperOffer(id, name, iProducts, discount);
                    case "BuyTwoOfTheSameGetOtherCheaperOffer":
                        return GetBuyTwoOfTheSameGetOtherCheaperOffer(id, name, iProducts, discount);
                    default: return null;
                }
            }
            return null;
        }
        public WeekOffer GetWeekOffer(int id, string name, IEnumerable<IProduct> affectedProducts, decimal discount, int weekAppliesTo)
        {
            return new WeekOffer() { Id = id, Name = name, ProductsAppliedTo = affectedProducts, Discount = discount, WeekAppliesTo = 20 };
        }
        public BuyTwoGetThemCheaperOffer GetBuyTwoGetThemCheaperOffer(int id, string name, IEnumerable<IProduct> affectedProducts, decimal discount)
        {
            return new BuyTwoGetThemCheaperOffer() { Id = id, Name = name, ProductsAppliedTo = affectedProducts, Discount = discount };
        }
        public BuyTwoOfTheSameGetOtherCheaperOffer GetBuyTwoOfTheSameGetOtherCheaperOffer(int id, string name, IEnumerable<IProduct> affectedProducts, decimal discount)
        {
            return new BuyTwoOfTheSameGetOtherCheaperOffer() { Id = id, Name = name, ProductsAppliedTo = affectedProducts, Discount = discount };
        }
    }
}
