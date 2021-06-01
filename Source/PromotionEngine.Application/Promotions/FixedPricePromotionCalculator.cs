using System.Linq;
using PromotionEngine.Model;

namespace PromotionEngine.Application.Promotions
{
    internal class FixedPricePromotionCalculator
    {
        public Cart FixedPricePromotion(Cart cart, string SKU, int setSize, decimal promotionalPrice)
        {
            var item = cart.CartItems.FirstOrDefault(x => x.Item.SKU == SKU);

            if (CheckIsPromotionApplicable(item, setSize))
            {
                var sets = item.Quantity / setSize;
                var reminder = item.Quantity % setSize;
                item.ItemPromotionTotal = (item.Item.Price * reminder) + (sets * promotionalPrice);

                item.IsPromotionApplied = true;
            }

            return cart;
        }

        private bool CheckIsPromotionApplicable(CartItem item, int setSize)
        {
            return item?.Quantity >= setSize;
        }
    }
}