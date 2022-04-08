using GroceryShop.Models;
using GroceryShop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using static GroceryShop.Data.ProductsCollections;
using static GroceryShop.Data.Constants;

namespace GroceryShop.Controllers
{
    public class HomeController : Controller
    {
        private IGroceryService groceryService;

        public HomeController(IGroceryService groceryService)
        {
            this.groceryService = groceryService;
        }

        public IActionResult OrderPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrderPage(Product product)
        {

            ModelState.Clear();

            var currentProuct = Products.Where(p => p.Name.ToLower() == product.Name.ToLower()).FirstOrDefault();

            if (currentProuct == null)
            {
                return BadRequest(ErrorMessageOnWrongProductInput);
            }

            OrderedProducts.Add(currentProuct);

            return View();
        }

        public IActionResult FinalizeOrder()
        {
            var totalPrice = this.groceryService.GetDiscounts(OrderedProducts);

            var finalOrder = new Order
            {
                TotalPrice = totalPrice
            };

            return View(finalOrder);
        }

    }
}
