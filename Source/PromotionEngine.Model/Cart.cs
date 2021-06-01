using System.Collections.Generic;

namespace PromotionEngine.Model
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; }

        public decimal Total { get; set; }
    }
}
