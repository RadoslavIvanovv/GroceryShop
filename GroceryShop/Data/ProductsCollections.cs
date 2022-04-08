using GroceryShop.Models;
using System.Collections.Generic;

namespace GroceryShop.Data
{
    public static class ProductsCollections
    {
        public static IReadOnlyCollection<Product> Products = new List<Product>
        {
            new Product { Name="Orange", Price = 0.80 },
            new Product { Name="Banana", Price = 0.40 },
            new Product { Name="Apple", Price = 0.50 },
            new Product { Name="Melon", Price = 1.50 },
            new Product { Name="Kiwi", Price = 0.90 },
            new Product { Name="Potato", Price = 0.26 },
            new Product { Name="Cucumber", Price = 1.10 },
            new Product { Name="Carrot", Price = 0.30 },
            new Product { Name="Spinach", Price = 1.00 },
            new Product { Name="Peas", Price = 2.00 }
        };

        public static List<Product> OrderedProducts = new List<Product>();
    }
}
