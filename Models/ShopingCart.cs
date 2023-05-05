namespace Labs.Models
{
    public class ShopingCart
    {
        public ShopingCart()
        {
            lstItems = new List<ShoppingCartItem>();     

        }
        public List<ShoppingCartItem> ? lstItems { get; set; }

        public decimal Total { get; set; }          // all total cart  

        public string? PromoCode { get; set; }
    }
}
