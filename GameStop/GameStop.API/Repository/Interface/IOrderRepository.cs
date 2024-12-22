using GameStop.API.Model;

namespace GameStop.API.Repository;

public interface IOrderRepository
{
    Order CreateNewOrder(Order order);
    IEnumerable<Order> GetOrders();
    Order GetOrderById(int id);
    Order UpdateOrder(int id, Order order);
    Order DeleteOrderById(int id);
}