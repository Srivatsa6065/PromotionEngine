using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Application.Promotions;
using PromotionEngine.Model;
using Xunit;

namespace PromotionEngine.Application.UnitTests
{
    public class SKUB2QuantityFixedPricePromotionTest
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 45)]
        [InlineData(3, 75)]
        public void ItemBN_Item_PP_N(int itemQty,decimal itemPromotionPrice)
        {
            //Arrange
            var cart = new Cart
            {
                CartItems = new List<CartItem>()
                {
                    new()
                    {
                        Item = new Item { SKU = "B", Price = 30},
                        Quantity = itemQty
                    },
                }
            };

            var promotion = new SKUB2QuantityFixedPricePromotion() ;

            //Act
            cart = promotion.ApplyPromotion(cart);
            var item = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "B");

            //Assert
            Assert.Equal(itemPromotionPrice, item?.ItemPromotionTotal);
        }
    }
}
