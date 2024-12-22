using GameStop.API.Model;

namespace GameStop.API.Service;

public interface IOrderService
{
    Order CreateNewOrder(Order order);
    IEnumerable<Order> GetOrders();
    Order GetOrderById(int id);
    Order UpdateOrder(int id, Order order);
    Order DeleteOrderById(int id);
}