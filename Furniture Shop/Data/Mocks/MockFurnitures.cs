using System.Collections.Generic;
using System.Linq;
using Furniture_Shop.Data.Interfaces;
using Furniture_Shop.Data.Models;

namespace Furniture_Shop.Data.Mocks
{
    public class MockFurnitures : IAllFurniture
    {
        private readonly IFurnitureCategory _furnitureCategory = new MockCategory();

        public IEnumerable<Furniture> Furnitures =>
            new List<Furniture>
            {
                new Furniture
                {
                    Id = 0,
                    Name = "Стіл обідній Peony",
                    ShortDescription = "Стіл обідній Peony",
                    FullDescription = "Матеріал стільниця: ДСП 18 мм, край ПВХ 2,0 або МДФ 16 мм",
                    ImageURL = "/img/Peony.webp",
                    Price = 3790,
                    IsOnSale = false,
                    OldPrice = 0,
                    InStockAmount = 20,
                    CategoryId = 0,
                    Category = _furnitureCategory.AllCategories.First(c => c.Id == 0)
                },
                new Furniture
                {
                    Id = 1,
                    Name = "Стіл Madrid",
                    ShortDescription = "Стіл Madrid",
                    FullDescription = "Матеріал каркас і ніжки: метал з порошковим фарбуванням",
                    ImageURL = "/img/Madrid.webp",
                    Price = 4230,
                    IsOnSale = false,
                    OldPrice = 0,
                    InStockAmount = 15,
                    CategoryId = 0,
                    Category = _furnitureCategory.AllCategories.First(c => c.Id == 0)
                },
                new Furniture
                {
                    Id = 2,
                    Name = "Диван Сіті New",
                    ShortDescription = "Диван Сіті New",
                    FullDescription = "Каркас: сосновий брус 45х45 мм",
                    ImageURL = "/img/Сіті New.webp",
                    Price = 12360,
                    IsOnSale = true,
                    OldPrice = 14000,
                    InStockAmount = 2,
                    CategoryId = 1,
                    Category = _furnitureCategory.AllCategories.First(c => c.Id == 1)
                }
            };

        public Furniture GetObjectFurniture(int id)
        {
            return this.Furnitures.First(f => f.Id == id);
        }

        public IEnumerable<Furniture> FurnituresOnSale => this.Furnitures.Where(f => f.IsOnSale);
    }
}