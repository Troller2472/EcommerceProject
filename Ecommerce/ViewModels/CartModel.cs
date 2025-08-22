namespace Ecommerce.ViewModels
{
    public class CartItem
    {
        public long id { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public string imgUrl { get; set; }
        public int quantity { get; set; }
        public string note { get; set; }
    }
}
