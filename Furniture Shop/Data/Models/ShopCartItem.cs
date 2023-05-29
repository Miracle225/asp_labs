namespace Furniture_Shop.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Furniture Furniture { get; set; }
        public string ShopCartId { get; set; }
    }
}