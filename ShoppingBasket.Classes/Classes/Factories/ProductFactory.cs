using ShoppingBasket.Classes.Classes.Implementations.Products;
using ShoppingBasket.Models;
using ShoppingBasket.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Classes.Classes.Factories
{
    public class ProductFactory
    {
        public List<IProduct> ReturnProducts()
        {
            List<IProduct> products = new List<IProduct>();
            products.Add(new Soup() { Name = "Soup", CountType = ProductCountEnum.Tin, Price = 0.65m, FlavorType = ProductFlavorEnum.Chicken });
            products.Add(new Bread() { Name = "Bread", CountType = ProductCountEnum.Loaf, Price = 0.80m, Calories = 251 });
            products.Add(new Pastries() { Name = "Roll", CountType = ProductCountEnum.Item, Price = 0.30m, Calories = 251 });
            products.Add(new Milk() { Name = "Full-Cream Milk", CountType = ProductCountEnum.Bottle, Price = 1.60m, Fat = 3.2m });
            products.Add(new Milk() { Name = "Low-Fat Milk", CountType = ProductCountEnum.Bottle, Price = 1.30m, Fat = 1.5m });
            products.Add(new Fruit() { Name = "Apples", CountType = ProductCountEnum.Bag, Price = 1.30m, Origin = "Poland" });
            return products;
        }
        public IProduct GetProduct(string productName)
        {
           switch(productName)
            {
                case "Soup":
                    return new Soup() { Name = "Soup", CountType = ProductCountEnum.Tin, Price = 0.65m, FlavorType = ProductFlavorEnum.Chicken };                    
                case "Bread":
                    return new Bread() { Name = "Bread", CountType = ProductCountEnum.Loaf, Price = 0.80m, Calories = 251 };
                case "Roll":
                    return new Pastries() { Name = "Roll", CountType = ProductCountEnum.Item, Price = 0.30m, Calories = 251 };
                case "Full-Cream Milk":
                    return new Milk() { Name = "Full-Cream Milk", CountType = ProductCountEnum.Bottle, Price = 1.60m, Fat = 3.2m };
                case "Low-Fat Milk":
                    return new Milk() { Name = "Low-Fat Milk", CountType = ProductCountEnum.Bottle, Price = 1.30m, Fat = 1.5m };
                case "Apples":
                    return new Fruit() { Name = "Apples", CountType = ProductCountEnum.Bag, Price = 1.30m, Origin = "Poland" };
                    default: return null;
            }
        }
        public IProduct GetProduct(object[] itemArray)
        {
            if(itemArray.Length > 0)
            {
                int id = int.Parse(itemArray[0].ToString());
                string name = itemArray[1].ToString().Trim();
                decimal price = decimal.Parse(itemArray[2].ToString());
                string type = itemArray[3].ToString().Trim();                
                switch (type)
                {
                    case "Soup":
                       return GetSoup(id, name, price, itemArray[7].ToString().Trim());
                    case "Bread":
                        return GetBread(id, name, price, int.Parse(itemArray[5].ToString()));
                    case "Pastries":
                        return GetPastries(id, name, price, int.Parse(itemArray[5].ToString()));
                    case "Milk":
                        return GetMilk(id, name, price, decimal.Parse(itemArray[4].ToString()));                   
                    case "Fruit":
                        return GetFruit(id, name, price, itemArray[5].ToString());
                    default: return null;
                }
            }
            return null;
        }
        public Soup GetSoup(int id, string name, decimal price, string flavor)
        {
            ProductFlavorEnum flavorEnum;
            Enum.TryParse(flavor, out flavorEnum);
            return new Soup() { Id = id, Name = name, CountType = ProductCountEnum.Tin, Price = price, FlavorType = flavorEnum };
        }
        public Bread GetBread(int id, string name, decimal price, int calories)
        {
            return new Bread() { Id = id, Name = name, CountType = ProductCountEnum.Loaf, Price = price, Calories = calories };
        }
        public Pastries GetPastries(int id, string name, decimal price, int calories)
        {
            return new Pastries() { Id = id, Name = name, CountType = ProductCountEnum.Item, Price = price, Calories = calories };
        }
        public Milk GetMilk(int id, string name, decimal price, decimal fat)
        {
            return new Milk() { Id = id, Name = name, CountType = ProductCountEnum.Bottle, Price = price, Fat = fat };
        }
        public Fruit GetFruit(int id, string name, decimal price, string origin)
        {
            return new Fruit() { Id = id, Name = name, CountType = ProductCountEnum.Bag, Price = price, Origin = origin };
        }
    }
}
