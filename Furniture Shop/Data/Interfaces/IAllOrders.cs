using Furniture_Shop.Data.Models;

namespace Furniture_Shop.Data.Interfaces
{
    public interface IAllOrders
    {
        void CreateOrder(Order order);
    }
}