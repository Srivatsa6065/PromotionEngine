using System.Collections.Generic;
using PromotionEngine.Model;
using Xunit;

namespace PromotionEngine.Application.UnitTests
{
    public class MultiSKUFixedPricePromotionTest
    {
        [Fact]
        public void ItemC1_ItemD1_TotalPrice30()
        {
            var cart = new Cart
            {
                CartItems = new List<CartItem>()
                {
                    new()
                    {
                        Item = new Item { SKU = "C", Price = 20 },
                        Quantity = 1
                    },
                    new()
                    {
                        Item = new Item { SKU = "D", Price = 15 },
                        Quantity = 1
                    },
                }
            };

            Assert.Equal(30m, cart.Total);
        }
    }
}
