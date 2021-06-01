using PromotionEngine.Model;

namespace PromotionEngine.Application.Promotions
{
    public class SKUB2QuantityFixedPricePromotion : IPromotion
    {
        private readonly FixedPricePromotionCalculator _fixedPricePromotionCalculator = new();

        public Cart ApplyPromotion(Cart cart)
        {
            const string SKU = "B";
            const int setSize = 2;
            const decimal promotionalPrice = 45;
            
            return _fixedPricePromotionCalculator.FixedPricePromotion(cart, SKU, setSize, promotionalPrice);
        }
    }
}
