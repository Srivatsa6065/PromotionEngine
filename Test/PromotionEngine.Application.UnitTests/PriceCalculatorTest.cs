using Moq;
using PromotionEngine.Model;
using Xunit;

namespace PromotionEngine.Application.UnitTests
{
    public class PriceCalculatorTest
    {
        [Fact]
        public void Validate_PromotionProcess_Invoked()
        {
            //Arrange
            var cart = new Cart();

            var promoProcessor = new Mock<IPromotionProcessor>();
            promoProcessor.Setup(x => x.ProcessPromotions(It.IsAny<Cart>())).Returns(cart);

            var priceCalculator = new PriceCalculator(promoProcessor.Object);

            //Act
            priceCalculator.CalculateCartTotal(cart);

            //Assert
            promoProcessor.VerifyAll();
        }


        [Theory]
        [InlineData(true, 100, 100)]
        [InlineData(false, 0, 50)]
        public void Validate_GetCartItemTotal(bool isPromotionApplied, int itemPromotionTotal, decimal total)
        {
            //Arrange
            var cartItem = new CartItem
            {
                Quantity = 5,
                IsPromotionApplied = isPromotionApplied,
                ItemPromotionTotal = itemPromotionTotal,
                Item = new Item
                {
                    SKU = "A",
                    Price = 10
                },
            };

            //Act
            var itemTotal = cartItem.GetCartItemTotal();

            //Assert
            Assert.Equal(total, itemTotal);
        }
    }
}
