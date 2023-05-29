using Furniture_Shop.Data.Interfaces;
using Furniture_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Furniture_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllFurniture _allFurniture;

        public HomeController(IAllFurniture allFurniture)
        {
            _allFurniture = allFurniture;
        }

        [Route("")]
        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                FurnitureOnSale = _allFurniture.FurnituresOnSale
            };
            return View(homeCars);
        }
    }
}