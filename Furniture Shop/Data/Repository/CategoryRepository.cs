using System.Collections.Generic;
using Furniture_Shop.Data.Interfaces;
using Furniture_Shop.Data.Models;

namespace Furniture_Shop.Data.Repository
{
    public class CategoryRepository : IFurnitureCategory
    {
        private readonly AppDBContent _appDbContent;

        public CategoryRepository(AppDBContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Category> AllCategories => _appDbContent.Category;
    }
}