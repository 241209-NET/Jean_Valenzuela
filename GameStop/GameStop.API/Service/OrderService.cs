using GameStop.API.Model;

namespace GameStop.API.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository) => _orderRepository = orderRepository;

    public Order CreateNewOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public Order DeleteOrderById(int id)
    {
        throw new NotImplementedException();
    }

    public Order GetOrderById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Order> GetOrders()
    {
        throw new NotImplementedException();
    }

    public Order UpdateOrder(int id, Order order)
    {
        throw new NotImplementedException();
    }
}