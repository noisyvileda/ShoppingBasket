using NUnit.Framework;
using ShoppingBasket.Classes.Classes.Factories;
using ShoppingBasket.Classes.Classes.Implementations.Offers;
using ShoppingBasket.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Tests
{
    [TestFixture]
    public class SpecialOfferTests
    {
        private ProductFactory ProductFactory;
        private DiscountFactory DiscountFactory;
        private IEnumerable<IProduct> Products;
        private IEnumerable<ISpecialOffer> SpecialOffers;
        [SetUp]
        public void SetUp()
        {
            ProductFactory = new ProductFactory();
            Products = ProductFactory.ReturnProducts();
            DiscountFactory = new DiscountFactory(Products);
            SpecialOffers = DiscountFactory.ReturnSpecialOffers();
        }
        [TearDown]
        public void TearDown()
        {
            ProductFactory = null;
            Products = null;
            DiscountFactory = null;
            SpecialOffers = null;
        }
        [Test]
        [TestCase("Soup",1,false)]
        [TestCase("Soup", 2, false)]
        [TestCase("Soup", 3, false)]
        public void AddSingleProductWithoutOffer_NoDiscount(string product, int offertype, bool assertion)
        {
            var item = ProductFactory.GetProduct(product);
            var products = new List<IProduct>() { item };
            var discount = SpecialOffers.ElementAt(offertype);
            Assert.That(discount.IsEnabled(products),Is.EqualTo(assertion));
        }
        [Test]
        [TestCase(20,false)]
        [TestCase(21, false)]
        [TestCase(22, true)]
        [TestCase(23, false)]
        public void WeekOfferTest_ShouldBeEnabledIfWeekMatches(int week, bool result)
        {            
            var specialOffer = new WeekOffer() { Name = "Apples 10% off in current week", ProductsAppliedTo = Products.Where(x => x.Name == "Apples").ToList(), Discount = 10m, WeekAppliesTo = 20 };
            Assert.That(specialOffer.IsEnabled(Products), Is.EqualTo(result));
        }
        [Test]
        [TestCase("Bread","Milk", true)]
        [TestCase("Soup", "Milk", false)]
        public void BuyTwoGetThemCheaperOffer_ShouldBeEnabledIfProductsMatch(string product1, string product2, bool result)
        {
            var specialOffer = SpecialOffers.ElementAt(2);
            var item1 = ProductFactory.GetProduct(product1);
            var item2 = ProductFactory.GetProduct(product2);
            var products = new List<IProduct>() { item1,item2 };
            Assert.That(specialOffer.IsEnabled(Products), Is.EqualTo(result));
        }
        [Test]
        [TestCase("Soup", "Milk", true)]
        [TestCase("Bread", "Milk", false)]
        public void BuyTwoOfTheSameGetOtherCheaperOffer_ShouldBeEnabledIfProductsMatch(string product1, string product2, bool result)
        {
            var specialOffer = SpecialOffers.ElementAt(3);
            var item1 = ProductFactory.GetProduct(product1);
            var item2 = ProductFactory.GetProduct(product2);
            var products = new List<IProduct>() { item1, item1, item2 };
            Assert.That(specialOffer.IsEnabled(Products), Is.EqualTo(result));
        }       
    }
}
