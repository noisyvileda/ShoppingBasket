using ShoppingBasket.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.SQLService.Services
{
    public interface IProductService
    {
         IEnumerable<IProduct> FetchProducts();
    }
}
