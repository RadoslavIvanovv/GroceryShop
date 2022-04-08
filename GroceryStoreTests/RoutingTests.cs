using GroceryShop.Controllers;
using MyTested.AspNetCore.Mvc;
using Xunit;

namespace GroceryStoreTests
{
    public class RoutingTests
    {
        [Fact]
        public void OrderPageShouldBeRoutedCorrectly()
          => MyRouting
              .Configuration()
              .ShouldMap("/Home/OrderPage")
              .To<HomeController>(c => c.OrderPage());

        [Fact]
        public void FinalizeOrderShouldBeRoutedCorrectly()
         => MyRouting
             .Configuration()
             .ShouldMap("/Home/FinalizeOrder")
             .To<HomeController>(c => c.FinalizeOrder());
    }
}
