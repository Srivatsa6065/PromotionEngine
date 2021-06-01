using PromotionEngine.Model;

namespace PromotionEngine.Application.Promotions
{
    public class SKUFixedPricePromotion : IPromotion
    {
        public Cart ApplyPromotion(Cart cart)
        {
            return cart;
        }
    }
}
