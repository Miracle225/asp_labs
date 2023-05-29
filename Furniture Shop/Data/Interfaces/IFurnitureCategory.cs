using System.Collections.Generic;
using Furniture_Shop.Data.Models;

namespace Furniture_Shop.Data.Interfaces
{
    public interface IFurnitureCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}