using System.Collections.Generic;
using System.Linq;
using Furniture_Shop.Data.Interfaces;
using Furniture_Shop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Furniture_Shop.Data.Repository
{
    public class FurnitureRepository : IAllFurniture
    {
        private readonly AppDBContent _appDbContent;

        public FurnitureRepository(AppDBContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Furniture> Furnitures => 
            _appDbContent.Furnitures.Include(f => f.Category);
        public Furniture GetObjectFurniture(int id)
        {
            return _appDbContent.Furnitures.Where(f => f.Id == id)
                .Include(f => f.Category).First();
        }

        public IEnumerable<Furniture> FurnituresOnSale => 
            _appDbContent.Furnitures.Where(f => f.IsOnSale)
                .Include(f => f.Category);
    }
}