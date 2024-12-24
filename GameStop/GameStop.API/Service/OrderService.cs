using System.Runtime.Serialization;
using GameStop.API.Model;
using GameStop.API.Repository;

namespace GameStop.API.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository) => _orderRepository = orderRepository;

    public Order CreateNewOrder(Order order)
    {
        return _orderRepository.CreateNewOrder(order);
    }

    public Order? DeleteOrderById(int id)
    {
        var order = GetOrderById(id);

        if ( order is not null ) _orderRepository.DeleteOrderById(id);

        return order;
    }

    public Order? GetOrderById(int id)
    {
        if(id < 1 ) return null;

        return _orderRepository.GetOrderById(id);
    }

    public IEnumerable<Order> GetOrders()
    {
        return _orderRepository.GetOrders();
    }

    public Order? UpdateOrder(int id, Order _order)
    {
        var order = GetOrderById(id);

        if( order is not null ) _orderRepository.UpdateOrder(id, _order);

        return order;
    }
}