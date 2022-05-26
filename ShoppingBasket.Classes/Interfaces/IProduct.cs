using ShoppingBasket.Classes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Classes.Interfaces
{
    public interface IProduct
    {
        int Id { get; set; }
        decimal Price { get; set; }
        string Name { get; set; }
        ProductCountEnum CountType { get;set; }        

    }
}
