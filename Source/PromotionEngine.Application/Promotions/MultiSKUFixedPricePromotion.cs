using System.Linq;
using PromotionEngine.Model;

namespace PromotionEngine.Application.Promotions
{
    public class MultiSKUFixedPricePromotion : IPromotion
    {
        public Cart ApplyPromotion(Cart cart)
        {
            var itemC = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "C");
            var itemD = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "D");

            if (CheckIsPromotionApplicable(itemC, itemD))
            {
                itemC.ItemPromotionTotal = 0;
                itemC.IsPromotionApplied = true;
                
                itemD.ItemPromotionTotal = 30;
                itemD.IsPromotionApplied = true;
            }
        

            return cart;
        }

        private static bool CheckIsPromotionApplicable(CartItem itemC, CartItem itemD)
        {
            return itemC?.Quantity > 0 && itemD?.Quantity > 0;
        }
    }
}
