using PromotionEngine.Model;

namespace PromotionEngine.Application
{
    public interface IPromotion
    {
        Cart ApplyPromotion(Cart cart);
    }
}
