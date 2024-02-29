namespace ETrade.WebUI.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public decimal TotalAmount {  get; set; }
    }
}
