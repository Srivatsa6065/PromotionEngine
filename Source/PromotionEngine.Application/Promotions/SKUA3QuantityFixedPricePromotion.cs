using PromotionEngine.Model;

namespace PromotionEngine.Application.Promotions
{
    public class SKUA3QuantityFixedPricePromotion : IPromotion
    {
        private readonly FixedPricePromotionCalculator _fixedPricePromotionCalculator = new();

        public Cart ApplyPromotion(Cart cart)
        {
            const string SKU = "A";
            const int setSize = 3;
            const decimal promotionalPrice = 130;

            return _fixedPricePromotionCalculator.FixedPricePromotion(cart, SKU, setSize, promotionalPrice);
        }
    }
}