using System.Linq;
using PromotionEngine.Model;

namespace PromotionEngine.Application.Promotions
{
    public class SKUCAndDFixedPricePromotion : IPromotion
    {
        public Cart ApplyPromotion(Cart cart)
        {
            var itemC = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "C");
            var itemD = cart.CartItems.FirstOrDefault(x => x.Item.SKU == "D");

            if (CheckIsPromotionApplicable(itemC, itemD))
            {
                const decimal promotionalPrice = 30;
                if (itemC.Quantity >= itemD.Quantity)
                {
                    itemC.ItemPromotionTotal = (itemC.Quantity - itemD.Quantity) * itemC.Item.Price;
                    itemD.ItemPromotionTotal = itemD.Quantity * promotionalPrice;
                }
                else
                {
                    itemC.ItemPromotionTotal = 0;
                    itemD.ItemPromotionTotal = (itemC.Quantity * promotionalPrice) + ((itemD.Quantity - itemC.Quantity) * itemD.Item.Price);
                }

                itemC.IsPromotionApplied = true;
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
