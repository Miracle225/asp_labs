using System.Collections.Generic;
using Furniture_Shop.Data.Models;

namespace Furniture_Shop.Data.Interfaces
{
    public interface IAllFurniture
    {
        IEnumerable<Furniture> Furnitures { get; }
        
        Furniture GetObjectFurniture(int id);
        
        IEnumerable<Furniture> FurnituresOnSale { get; }
    }
}