using System.Collections.Generic;
using PromotionEngine.Model;

namespace PromotionEngine.Application
{
    public interface IPromotionProcessor
    {
        Cart ProcessPromotions(Cart cart);
    }

    public class PromotionProcessor : IPromotionProcessor
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
