using System.Collections.Generic;

namespace Furniture_Shop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Furniture> Furnitures { get; set; }
    }
}