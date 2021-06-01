using PromotionEngine.Model;

namespace PromotionEngine.Application.Promotions
{
    public class MultiSKUFixedPricePromotion : IPromotion
    {
        public Cart ApplyPromotion(Cart cart)
        {
            return cart;
        }
    }
}
