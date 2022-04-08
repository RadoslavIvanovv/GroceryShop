using GroceryShop.Models;
using GroceryShop.Services;
using System.Collections.Generic;
using Xunit;

namespace GroceryStoreTests
{
    public class UnitTests
    {

        private readonly IGroceryService groceryService;
        private List<Product> products;

        public UnitTests()
        {
            this.groceryService = new GroceryService();
            this.products = new List<Product>();
        }

        [Fact]
        public void MethodShouldReturnCorrectOutputIfNoDiscountsAreSuitable()
        {
            products.Add(new Product { Name = "Orange", Price = 0.80 });
            products.Add(new Product { Name = "Banana", Price = 0.40 });

            var totalPrice = groceryService.GetDiscounts(products);

            Assert.Equal(1.20,totalPrice);
        }

        [Fact]
        public void MethodShouldReturnCorrectOutputIfCollectionCountIsEqualTo3()
        {
            products.Add(new Product { Name = "Orange", Price = 0.80 });
            products.Add(new Product { Name = "Banana", Price = 0.40 });
            products.Add(new Product { Name = "Carrot", Price = 0.30 });

            var totalPrice = groceryService.GetDiscounts(products);

            Assert.Equal(1.20, totalPrice);
        }

        [Fact]
        public void MethodShouldReturnCorrectOutputIfCollectionCountIsMoreThan3()
        {
            products.Add(new Product { Name = "Orange", Price = 0.80 });
            products.Add(new Product { Name = "Banana", Price = 0.40 });
            products.Add(new Product { Name = "Carrot", Price = 0.30 });
            products.Add(new Product { Name = "Potato", Price = 0.26 });
            products.Add(new Product { Name = "Kiwi", Price = 0.90 });

            var totalPrice = groceryService.GetDiscounts(products);

            Assert.Equal(2.36, totalPrice);
        }

        [Fact]
        public void MethodShouldReturnCorrectOutputIfInputHasMoreThanOneProductOfSameType()
        {
            products.Add(new Product { Name = "Orange", Price = 0.80 });
            products.Add(new Product { Name = "Orange", Price = 0.80 });

            var totalPrice = groceryService.GetDiscounts(products);

            Assert.Equal(1.20, totalPrice);
        }

        [Fact]
        public void MethodShouldReturnCorrectOutputIfBothDiscountsAreSuitable()
        {
            products.Add(new Product { Name = "Banana", Price = 0.40 });
            products.Add(new Product { Name = "Carrot", Price = 0.30 });
            products.Add(new Product { Name = "Potato", Price = 0.26 });
            products.Add(new Product { Name = "Orange", Price = 0.80 });
            products.Add(new Product { Name = "Kiwi", Price = 0.90 });
            products.Add(new Product { Name = "Orange", Price = 0.80 });

            var totalPrice = groceryService.GetDiscounts(products);

            Assert.Equal(2.80, totalPrice);
        }

        [Fact]
        public void MethodShouldReturnCorrectOutputIfBothDiscountsAreSuitableButIfTheRepeatedProductIsInTheFirstDiscountItDoesNotCountInTheSecond()
        {
            products.Add(new Product { Name = "Orange", Price = 0.80 });
            products.Add(new Product { Name = "Banana", Price = 0.40 });
            products.Add(new Product { Name = "Carrot", Price = 0.30 });
            products.Add(new Product { Name = "Potato", Price = 0.26 });
            products.Add(new Product { Name = "Kiwi", Price = 0.90 });
            products.Add(new Product { Name = "Orange", Price = 0.80 });

            var totalPrice = groceryService.GetDiscounts(products);

            Assert.Equal(3.16, totalPrice);
        }

        [Fact]
        public void MethodShouldReturnCorrectOutputIfBothDiscountsAreSuitableButOnlyTheFirstShouldCount()
        {
            products.Add(new Product { Name = "Banana", Price = 0.40 });
            products.Add(new Product { Name = "Carrot", Price = 0.30 });
            products.Add(new Product { Name = "Carrot", Price = 0.30 });

            var totalPrice = groceryService.GetDiscounts(products);

            Assert.Equal(0.70, totalPrice);
        }
    }
}
