using GroceryShop.Models;
using System.Collections.Generic;

namespace GroceryShop.Services
{
    public interface IGroceryService
    {
        double GetDiscounts(List<Product> products);
    }
}
