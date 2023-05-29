namespace Furniture_Shop.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int FurnitureID { get; set; }
        public decimal Price { get; set; }
        public virtual Furniture Furniture { get; set; }
        public virtual Order Order { get; set; }
    }
}