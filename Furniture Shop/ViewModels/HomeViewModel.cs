using System.Collections.Generic;
using Furniture_Shop.Data.Models;

namespace Furniture_Shop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Furniture> FurnitureOnSale { get; set; }
    }
}