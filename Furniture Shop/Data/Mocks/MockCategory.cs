using System.Collections.Generic;
using Furniture_Shop.Data.Interfaces;
using Furniture_Shop.Data.Models;

namespace Furniture_Shop.Data.Mocks
{
    public class MockCategory : IFurnitureCategory
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category
                {
                    Id = 0,
                    Name = "Tables",
                    Description = "Various tables for your kitchen",
                    Furnitures = null
                },
                new Category
                {
                    Id = 1,
                    Name = "Sofas",
                    Description = "Comfort for your living room",
                    Furnitures = null
                },
                new Category
                {
                    Id = 2,
                    Name = "Bookshelves",
                    Description = "Organize your books",
                    Furnitures = null
                }
            };
    }
}