using PromotionEngine.Model;

namespace PromotionEngine.Application
{
    internal static class CartItemExtension
    {
        public static decimal GetCartItemTotal(this CartItem cartItem)
        {
            if (cartItem.IsPromotionApplied)
            {
                return cartItem.ItemPromotionTotal;
            }

            cartItem.ItemTotal = cartItem.Quantity * cartItem.Item.Price;
            return cartItem.ItemTotal;
        }
    }
}