using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Furniture_Shop.Data.Models
{
    public class ShopCart
    {
        // TODO: Get rid of business logic in MODEL CLASS!!!!

        //змінна для роботи з класом налаштувань БД AppDBContext.cs
        private readonly AppDBContent _appDbContent;

        public ShopCart(AppDBContent appDbContent)
        {
            this._appDbContent = appDbContent;
        }

        public string ShopCartId { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            //створюємо об'єкт для роботи з сессією
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDBContent>();

            //перевіряємо чи був створений кошик чи створюємо новий
            string shopCartId = session.GetString("CartId") ??
                                Guid.NewGuid().ToString(); //id кошика

            //присваюємо id кошика сессії
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        //функція додавання товару до кошика
        public void AddToCart(Furniture furniture)
        {
            _appDbContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Furniture = furniture,
            });
            _appDbContent.SaveChanges();
        }

        //функція відображення товарів в кошику
        public List<ShopCartItem> GetShopItems()
        {
            return _appDbContent.ShopCartItem
                .Where(i => i.ShopCartId == ShopCartId)
                .Include(sc => sc.Furniture)
                .ToList();
        }
    }
}