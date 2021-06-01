using System.Collections.Generic;
using PromotionEngine.Model;

namespace PromotionEngine.Application
{
    public class PromotionProcessor
    {
        private readonly IEnumerable<IPromotion> _promotions;

        public PromotionProcessor(IEnumerable<IPromotion> promotions)
        {
            _promotions = promotions;
        }

        public Cart ProcessPromotions(Cart cart)
        {
            foreach (var promotion in _promotions)
            {
                cart = promotion.ApplyPromotion(cart);
            }
            return cart;
        }
    }
}
