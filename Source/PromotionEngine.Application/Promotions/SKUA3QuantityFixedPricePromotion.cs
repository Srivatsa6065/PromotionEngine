using System.Linq;
using PromotionEngine.Model;

namespace PromotionEngine.Application.Promotions
{
    public class SKUA3QuantityFixedPricePromotion : IPromotion
    {
        public Cart ApplyPromotion(Cart cart)
        {
            var itemA = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "A");

            if (CheckIsPromotionApplicable(itemA))
            {
                const decimal promotionalPrice = 130;
                var setsOf3 = itemA.Quantity / 3;
                var reminder = itemA.Quantity % 3;
                itemA.ItemPromotionTotal = (itemA.Item.Price * reminder) + (setsOf3 * promotionalPrice);

                itemA.IsPromotionApplied = true;
            }
            return cart;
        }

        private static bool CheckIsPromotionApplicable(CartItem itemA)
        {
            return itemA?.Quantity >= 3;
        }
    }
}
