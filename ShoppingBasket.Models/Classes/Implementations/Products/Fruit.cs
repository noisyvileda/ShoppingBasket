using ShoppingBasket.Models;
using ShoppingBasket.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Classes.Classes.Implementations.Products
{
    public class Fruit : IProduct
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public ProductCountEnum CountType { get; set; }

        public override string ToString()
        {
            return $@"Name : {Name} {Environment.NewLine} Price : {Price}$ per {CountType} {Environment.NewLine} Origin : {Origin}";
        }
    }
}
