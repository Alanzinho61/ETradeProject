namespace ETrade.WebUI.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount => ProductPrice * Quantity;
    }
}
