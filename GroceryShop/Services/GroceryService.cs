using GroceryShop.Models;
using System;
using System.Collections.Generic;

using static GroceryShop.Data.ProductsCollections;

namespace GroceryShop.Services
{
    public class GroceryService : IGroceryService
    {
        public double GetDiscounts(List<Product> products)
        {
            var totalPrice = GetTotalPrice(products);

            var totalPriceAfterFirstDiscount = GetDiscountForThreeOrMoreItems(products, totalPrice);
            var totalPriceAfterSecondDiscount = GetDiscountForProductsOfTheSameType(products, totalPriceAfterFirstDiscount);

            var totalPriceRounded= Math.Round(totalPriceAfterSecondDiscount, 2);

            return totalPriceRounded;
        }

        private double GetTotalPrice(List<Product> products)
        {
            var sum = 0.00;

            foreach(var product in products)
            {
                sum += product.Price;
            }

            return sum;
        }
        
        private double GetDiscountForThreeOrMoreItems(List<Product> products, double totalPrice)
        {
            if (products.Count >= 3)
            {
                var lowestCostProduct = new Product();

                var firstProductPrice = products[0].Price;
                var secondProductPrice = products[1].Price;
                var thirdProductPrice = products[2].Price;

                var firstProductName = products[0].Name;
                var secondProductName = products[1].Name;
                var thirdProductName = products[2].Name;


                if (firstProductPrice <= secondProductPrice && firstProductPrice <= thirdProductPrice)
                {
                    lowestCostProduct.Name = firstProductName;
                    lowestCostProduct.Price = firstProductPrice;
                }
                else if(secondProductPrice <= firstProductPrice && secondProductPrice <= thirdProductPrice)
                {
                    lowestCostProduct.Name = secondProductName;
                    lowestCostProduct.Price = secondProductPrice;
                }
                else if (thirdProductPrice <= firstProductPrice && thirdProductPrice <= secondProductPrice)
                {
                    lowestCostProduct.Name = thirdProductName;
                    lowestCostProduct.Price = thirdProductPrice;
                }

                totalPrice -= lowestCostProduct.Price;
            }

            return totalPrice;
        }

        private double GetDiscountForProductsOfTheSameType(List<Product> products, double totalPrice)
        {
            var discountAmount = 0.00;

            if (products.Count > 3)
            {
                for (int i = 3; i < products.Count; i++)
                {
                    var currentProduct = products[i];

                    for (int j = i+1; j < products.Count; j++)
                    {
                        if (currentProduct.Name == products[j].Name)
                        {
                            var halvedPrice = currentProduct.Price / 2;

                            discountAmount += halvedPrice;

                            totalPrice -= discountAmount;

                            return totalPrice;
                        }
                    }
                }
            }
            else if(products.Count==2)
            {
                var firstProductName = products[0].Name;
                var secondProductName = products[1].Name;

                var productPrice = products[0].Price;

                if (firstProductName == secondProductName)
                {
                    var halvedPrice = productPrice / 2;

                    discountAmount += halvedPrice;

                    totalPrice -= discountAmount;
                }
            }
            return totalPrice;
        }
    }
}
