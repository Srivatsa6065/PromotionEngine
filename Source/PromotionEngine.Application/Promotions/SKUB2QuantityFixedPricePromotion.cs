using System.Linq;
using PromotionEngine.Model;

namespace PromotionEngine.Application.Promotions
{
    public class SKUB2QuantityFixedPricePromotion : IPromotion
    {
        public Cart ApplyPromotion(Cart cart)
        {
            const string SKU = "B";
            const int setSize = 2;
            const decimal promotionalPrice = 45;
            
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

        private static bool CheckIsPromotionApplicable(CartItem item, int setSize)
        {
            return item?.Quantity >= setSize;
        }
    }
}
