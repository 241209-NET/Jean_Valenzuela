using System.Runtime.Serialization;
using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Repository;
using GameStop.API.Utils;

namespace GameStop.API.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository) => _orderRepository = orderRepository;

    public Order CreateNewOrder(OrderDTO _order)
    {
        Order order = new();

        DTOToEntityRequest<OrderDTO, Order>.ToEntity(_order, order);

        return _orderRepository.CreateNewOrder(order, _order.GameId);
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

    public Order? UpdateOrder(int id, string status)
    {
        var order = GetOrderById(id);

        if( order is not null ) _orderRepository.UpdateOrder(id, status);

        return order;
    }
}