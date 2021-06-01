namespace PromotionEngine.Model
{
    public class CartItem
    {
        public Item Item { get; set; }

        public int Quantity { get; set; }

        public bool IsPromotionApplied { get; set; }

        public decimal ItemTotal { get; set; }

        public decimal ItemPromotionTotal { get; set; }
    }
}
