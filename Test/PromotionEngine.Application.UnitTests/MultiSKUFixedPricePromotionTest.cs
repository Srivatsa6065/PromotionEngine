using System.Collections.Generic;
using PromotionEngine.Application.Promotions;
using PromotionEngine.Model;
using Xunit;

namespace PromotionEngine.Application.UnitTests
{
    public class MultiSKUFixedPricePromotionTest
    {
        [Fact]
        public void ItemC1_ItemD1_TotalPrice30()
        {
            //Arrange
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

            var promotions = new List<IPromotion> {new MultiSKUFixedPricePromotion()};
            var promotionProcessor = new PromotionProcessor(promotions);

            //Act
            cart = promotionProcessor.ProcessPromotions(cart);

            //Assert
            Assert.Equal(30m, cart.Total);
        }
    }
}
