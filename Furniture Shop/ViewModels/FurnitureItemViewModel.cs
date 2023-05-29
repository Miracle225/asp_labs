using Furniture_Shop.Data.Models;

namespace Furniture_Shop.ViewModels
{
    public class FurnitureItemViewModel
    {
        public bool IsNotFound { get; set; }
        public Furniture Furniture { get; set; }
        public Category Category { get; set; }
    }
}