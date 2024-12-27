using GameStop.API.Model;

namespace GameStop.API.Repository;

public interface IOrderRepository
{
    Order CreateNewOrder(Order order, int[] games);
    IEnumerable<Order> GetOrders();
    Order? GetOrderById(int id);
    void UpdateOrder(int id, string Status);
    void DeleteOrderById(int id);
}