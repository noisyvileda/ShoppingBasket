using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Classes.Interfaces
{
    public interface ISpecialOffer
    {
        int Id { get; set; }
        string Name { get; set; }
        IEnumerable<IProduct> ProductsAppliedTo { get; set; }
        decimal Discount { get; set; }
        decimal CalculatedDiscount { get; set; }
        void CalculateSpecialOffer(IEnumerable<IProduct> products);
        bool IsEnabled(IEnumerable<IProduct> products);


    }
}
