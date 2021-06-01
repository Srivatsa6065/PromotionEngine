using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Application.Promotions;
using PromotionEngine.Model;
using Xunit;

namespace PromotionEngine.Application.UnitTests
{
    public class MultiSKUFixedPricePromotionTest
    {
        [Fact]
        public void ItemC1_ItemD1_ItemC_PP_0_ItemD_PP_30()
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

            var promotions = new List<IPromotion> { new MultiSKUFixedPricePromotion() };
            var promotionProcessor = new PromotionProcessor(promotions);

            //Act
            cart = promotionProcessor.ProcessPromotions(cart);
            var itemC = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "C");
            var itemD = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "D");


            //Assert
            Assert.Equal(0, itemC?.ItemPromotionTotal);
            Assert.Equal(30, itemD?.ItemPromotionTotal);
        }

        [Fact]
        public void ItemC0_ItemD1_ItemC_PP_0_ItemD_PP_0()
        {
            //Arrange
            var cart = new Cart
            {
                CartItems = new List<CartItem>()
                {
                    new()
                    {
                        Item = new Item { SKU = "D", Price = 15 },
                        Quantity = 1
                    },
                }
            };

            var promotions = new List<IPromotion> { new MultiSKUFixedPricePromotion() };
            var promotionProcessor = new PromotionProcessor(promotions);

            //Act
            cart = promotionProcessor.ProcessPromotions(cart);
            var itemD = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "D");

            //Assert
            Assert.Equal(0, itemD?.ItemPromotionTotal);
        }

        [Fact]
        public void ItemC1_ItemD0_ItemC_PP_0_ItemD_PP_0()
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
                }
            };

            var promotions = new List<IPromotion> { new MultiSKUFixedPricePromotion() };
            var promotionProcessor = new PromotionProcessor(promotions);

            //Act
            cart = promotionProcessor.ProcessPromotions(cart);
            var itemC = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "C");

            //Assert
            Assert.Equal(0, itemC?.ItemPromotionTotal);
        }

        [Fact]
        public void ItemC2_ItemD2_ItemC_PP_0_ItemD_PP_60()
        {
            //Arrange
            var cart = new Cart
            {
                CartItems = new List<CartItem>()
                {
                    new()
                    {
                        Item = new Item { SKU = "C", Price = 20 },
                        Quantity = 2
                    },
                    new()
                    {
                        Item = new Item { SKU = "D", Price = 15 },
                        Quantity = 2
                    },
                }
            };

            var promotions = new List<IPromotion> { new MultiSKUFixedPricePromotion() };
            var promotionProcessor = new PromotionProcessor(promotions);

            //Act
            cart = promotionProcessor.ProcessPromotions(cart);
            var itemC = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "C");
            var itemD = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "D");


            //Assert
            Assert.Equal(0, itemC?.ItemPromotionTotal);
            Assert.Equal(60, itemD?.ItemPromotionTotal);
        }

        [Theory]
        [InlineData(1, 1, 0, 30)]
        [InlineData(2, 2, 0, 60)]
        [InlineData(3, 2, 20, 60)]
        [InlineData(2, 3, 0, 75)]
        [InlineData(0, 3, 0, 0)]
        [InlineData(3, 0, 0, 0)]
        public void ItemCN_ItemDN_ItemC_PP_N_ItemD_PP_N(int itemCQty,int itemDQty,decimal itemCQtyPP, decimal itemDQtyPP)
        {
            //Arrange
            var cart = new Cart
            {
                CartItems = new List<CartItem>()
                {
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

            var promotions = new List<IPromotion> { new MultiSKUFixedPricePromotion() };
            var promotionProcessor = new PromotionProcessor(promotions);

            //Act
            cart = promotionProcessor.ProcessPromotions(cart);
            var itemC = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "C");
            var itemD = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "D");


            //Assert
            Assert.Equal(itemCQtyPP, itemC?.ItemPromotionTotal);
            Assert.Equal(itemDQtyPP, itemD?.ItemPromotionTotal);
        }
    }
}
