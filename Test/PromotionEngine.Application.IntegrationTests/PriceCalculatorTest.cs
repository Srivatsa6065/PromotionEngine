using System.Collections.Generic;
using PromotionEngine.Application.Promotions;
using PromotionEngine.Model;
using Xunit;

namespace PromotionEngine.Application.UnitTests
{
    public class PriceCalculatorTest
    {
        [Theory]
        [InlineData(1, 1, 1, 0, 100)]
        [InlineData(5, 5, 1, 0, 370)]
        [InlineData(3, 5, 1, 1, 280)]
        public void Validate_CartTotal(int itemAQty, int itemBQty, int itemCQty, int itemDQty, int total)
        {
            //Arrange
            var cart = new Cart
            {
                CartItems = new List<CartItem>()
                {
                    new()
                    {
                        Item = new Item { SKU = "A", Price = 50 },
                        Quantity = itemAQty
                    },
                    new()
                    {
                        Item = new Item { SKU = "B", Price = 30 },
                        Quantity = itemBQty
                    },
                    new()
                    {
                        Item = new Item { SKU = "C", Price = 20 },
                        Quantity = itemCQty
                    },
                    new()
                    {
                        Item = new Item { SKU = "D", Price = 15 },
                        Quantity = itemDQty
                    },
                }
            };

            var promotions = new List<IPromotion> { new SKUA3QuantityFixedPricePromotion(), new SKUB2QuantityFixedPricePromotion(), new SKUCAndDFixedPricePromotion() };
            var promotionProcessor = new PromotionProcessor(promotions);
            var priceCalculator = new PriceCalculator(promotionProcessor);

            //Act
            cart = priceCalculator.CalculateCartTotal(cart);


            //Assert
            Assert.Equal(total, cart.Total);
        }
    }
}
