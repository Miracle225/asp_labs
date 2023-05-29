using System;
using Furniture_Shop.Data.Interfaces;
using Furniture_Shop.Data.Models;

namespace Furniture_Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent _appDbContent;
        private readonly ShopCart _shopCart;

        public OrdersRepository(AppDBContent appDbContent, ShopCart shopCart)
        {
            _appDbContent = appDbContent;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _appDbContent.Order.Add(order);
            _appDbContent.SaveChanges();
            var items = _shopCart.ListShopItems;
            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    FurnitureID = el.Furniture.Id,
                    OrderID = order.Id,
                    Price = el.Furniture.Price
                };
                _appDbContent.OrderDetail.Add(orderDetail);
            }

            _appDbContent.SaveChanges();
        }
    }
}