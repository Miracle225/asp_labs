using System.Collections.Generic;
using Furniture_Shop.Data.Models;

namespace Furniture_Shop.ViewModels
{
    public class FurnitureListViewModel
    {
        public IEnumerable<Furniture> AllFurniture { get; set; }
        public string CategoryName { get; set; }
    }
}