using System.Linq;
using PromotionEngine.Model;

namespace PromotionEngine.Application
{
    public class PriceCalculator
    {
        private readonly IPromotionProcessor _promotionProcessor;

        public PriceCalculator(IPromotionProcessor promotionProcessor)
        {
            _promotionProcessor = promotionProcessor;
        }

        public Cart CalculateCartTotal(Cart cart)
        {
            cart = _promotionProcessor.ProcessPromotions(cart);
            var cartTotal = cart.CartItems.Sum(cartItem => cartItem.GetCartItemTotal());
            cart.Total = cartTotal;
            return cart;
        }
    }
}