using System.Collections.Generic;
using System.Linq;
using Furniture_Shop.Data.Models;

namespace Furniture_Shop.Data
{
    public class DBObjects
    {
        //функція для підключення до БД
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Furnitures.Any())
            {
                content.AddRange(
                    new Furniture
                    {
                        Name = "Стіл обідній Peony",
                        ShortDescription = "Стіл обідній Peony",
                        FullDescription = "Матеріал стільниця: ДСП 18 мм, край ПВХ 2,0 або МДФ 16 мм",
                        ImageURL = "/img/Peony.webp",
                        Price = 3790,
                        IsOnSale = false,
                        OldPrice = 0,
                        InStockAmount = 20,
                        Category = Categories["Tables"],
                    },
                    new Furniture
                    {
                        Name = "Стіл Madrid",
                        ShortDescription = "Стіл Madrid",
                        FullDescription = "Матеріал каркас і ніжки: метал з порошковим фарбуванням",
                        ImageURL = "/img/Madrid.webp",
                        Price = 4230,
                        IsOnSale = false,
                        OldPrice = 0,
                        InStockAmount = 15,
                        Category = Categories["Tables"],
                    },
                    new Furniture
                    {
                        Name = "Диван Сіті New",
                        ShortDescription = "Диван Сіті New",
                        FullDescription = "Каркас: сосновий брус 45х45 мм",
                        ImageURL = "/img/Сіті New.webp",
                        Price = 12360,
                        IsOnSale = true,
                        OldPrice = 14000,
                        InStockAmount = 2,
                        Category = Categories["Sofas"],
                    }
                );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    //створення інфомаціїї для занесення в БД
                    var list = new Category[]
                    {
                        new Category
                        {
                            Name = "Tables",
                            Description = "Various tables for your kitchen",
                            Furnitures = null
                        },
                        new Category
                        {
                            Name = "Sofas",
                            Description = "Comfort for your living room",
                            Furnitures = null
                        },
                        new Category
                        {
                            Name = "Bookshelves",
                            Description = "Organize your books",
                            Furnitures = null
                        }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.Name, el);
                    }
                }

                return category;
            }
        }
    }
}