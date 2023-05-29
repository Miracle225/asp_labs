using System;
using System.Linq;
using Furniture_Shop.Data.Interfaces;
using Furniture_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Furniture_Shop.Controllers
{
    public class FurnituresController : Controller
    {
        private readonly IAllFurniture _allFurniture;
        private readonly IFurnitureCategory _furnitureCategory;

        public FurnituresController(IAllFurniture allFurniture, IFurnitureCategory furnitureCategory)
        {
            _allFurniture = allFurniture;
            _furnitureCategory = furnitureCategory;
        }

        [Route("Furnitures/List")]
        [Route("Furnitures/List/{category}")]
        public ViewResult List(string category = "")
        {
            // Is search by category and category exists
            bool isCategorized = !string.IsNullOrEmpty(category)
                                 && _furnitureCategory
                                     .AllCategories
                                     .Any(c => c.Name == category);

            var categoryEntity = isCategorized
                ? _furnitureCategory
                    .AllCategories
                    .FirstOrDefault(c => c.Name == category)
                : null;

            FurnitureListViewModel model = new FurnitureListViewModel();
            model.CategoryName = isCategorized ? category : "Whole list";

            model.AllFurniture = isCategorized
                ? _allFurniture
                    .Furnitures
                    .Where(f => f.Category.Id == categoryEntity.Id)
                : _allFurniture
                    .Furnitures;
            
            ViewBag.Title = model.CategoryName;
            return View(model);
        }

        public ViewResult Furniture([FromRoute] int id)
        {
            FurnitureItemViewModel model = new FurnitureItemViewModel();
            try
            {
                model.Furniture = _allFurniture.Furnitures.First(f => f.Id == id);
                model.Category = _furnitureCategory.AllCategories.First(c => c.Id == model.Furniture.Category.Id);
                model.IsNotFound = false;
            }
            catch (Exception e)
            {
                model.IsNotFound = true;
            }

            if (model.Furniture is null || model.Category is null) model.IsNotFound = true;
            ViewBag.Title = model.IsNotFound ? "Not found" : model.Furniture.Name;
            return View(model);
        }
    }
}