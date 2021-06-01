using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Application.Promotions;
using PromotionEngine.Model;
using Xunit;

namespace PromotionEngine.Application.UnitTests
{
    public class SKUA3QuantityFixedPricePromotionTest
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(3, 130)]
        [InlineData(4, 180)]
        [InlineData(6, 260)]
        [InlineData(7, 310)]
        public void ItemAN_Item_PP_N(int itemQty,decimal itemPromotionPrice)
        {
            //Arrange
            var cart = new Cart
            {
                CartItems = new List<CartItem>()
                {
                    new()
                    {
                        Item = new Item { SKU = "A", Price = 50 },
                        Quantity = itemQty
                    },
                }
            };

            var promotion = new SKUA3QuantityFixedPricePromotion() ;

            //Act
            cart = promotion.ApplyPromotion(cart);
            var item = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "A");

            //Assert
            Assert.Equal(itemPromotionPrice, item?.ItemPromotionTotal);
        }
    }
}
