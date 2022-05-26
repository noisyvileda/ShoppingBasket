using ShoppingBasket.Models;
using ShoppingBasket.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDataService.Interfaces
{
    public interface IFetchDataService
    {
        IEnumerable<IProduct> GetProducts();
        IEnumerable<ISpecialOffer> GetSpecialOffers(IEnumerable<IProduct> products);
    }
}
