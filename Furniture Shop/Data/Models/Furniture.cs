using System.ComponentModel.DataAnnotations.Schema;

namespace Furniture_Shop.Data.Models
{
    public class Furniture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public bool IsOnSale { get; set; }
        public decimal OldPrice { get; set; }
        public uint InStockAmount { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { set; get; }
    }
}