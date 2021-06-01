using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngine.Model;
using Xunit;

namespace PromotionEngine.Application.UnitTests
{
    public class MultiSKUFixedPricePromotionTest
    {
        [Fact]
        public void ItemC1_ItemD1_TotalPrice30()
        {
            var cartItems = new List<CartItem>()
            {
                new CartItem
                {
                    Item = new Item {SKU = "C", Price = 20},
                    Quantity = 1
                },
                new CartItem
                {
                    Item = new Item {SKU = "D", Price = 15},
                    Quantity = 1
                },
            };
            var cart = new Cart
            {
                CartItems = cartItems
            };

            Assert.Equal(30m, cart.Total);
        }
    }
}
