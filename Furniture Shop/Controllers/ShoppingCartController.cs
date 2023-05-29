using System.Linq;
using Furniture_Shop.Data.Interfaces;
using Furniture_Shop.Data.Models;
using Furniture_Shop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

namespace Furniture_Shop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IAllFurniture _allFurniture;
        private readonly ShopCart _shopCart;

        public ShoppingCartController(IAllFurniture allFurniture, ShopCart shopCart)
        {
            _allFurniture = allFurniture;
            _shopCart = shopCart;
        }

        [Authorize]
        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;
            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };
            return View(obj);
        }
        
        [Authorize]
        public RedirectToActionResult AddToCart(int id){
            var item = _allFurniture
                .Furnitures
                .FirstOrDefault(i => i.Id == id);
            
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}