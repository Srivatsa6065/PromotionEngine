using System.Collections.Generic;
using Moq;
using PromotionEngine.Model;
using Xunit;

namespace PromotionEngine.Application.UnitTests
{
    public class PromotionProcessorTest
    {
        [Fact]
        public void Validate_All_Promotion_Invoked()
        {
            var cart = new Cart();

            var promo1 = new Mock<IPromotion>();
            promo1.Setup(x => x.ApplyPromotion(It.IsAny<Cart>()));

            var promo2 = new Moq.Mock<IPromotion>();
            promo2.Setup(x => x.ApplyPromotion(It.IsAny<Cart>()));

            var promos = new List<IPromotion> {promo1.Object, promo2.Object};

            var promotionProcessor = new PromotionProcessor(promos);
            promotionProcessor.ProcessPromotions(cart);

            promo1.VerifyAll();
            promo2.VerifyAll();
        }
    }
}
