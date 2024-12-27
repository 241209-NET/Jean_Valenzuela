using GameStop.API.DTO;
using GameStop.API.Model;

namespace GameStop.API.Service;

public interface IOrderService
{
    Order CreateNewOrder(OrderDTO order);
    IEnumerable<Order> GetOrders();
    Order? GetOrderById(int id);
    Order? UpdateOrder(int id, string status);
    Order? DeleteOrderById(int id);
}