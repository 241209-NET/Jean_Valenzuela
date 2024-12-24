using GameStop.API.Data;
using GameStop.API.Model;

namespace GameStop.API.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly GameStopContext _gameStopContext;
    public OrderRepository(GameStopContext gameStopContext) => _gameStopContext = gameStopContext;
    
    public Order CreateNewOrder(Order order)
    {
        _gameStopContext.Orders.Add(order);
        _gameStopContext.SaveChanges();
        return order;
    }

    public void DeleteOrderById(int id)
    {
        var order = GetOrderById(id);

        _gameStopContext.Orders.Remove(order!);
        _gameStopContext.SaveChanges();
    }

    public Order? GetOrderById(int id)
    {
        return _gameStopContext.Orders.Find(id);
    }

    public IEnumerable<Order> GetOrders()
    {
        return _gameStopContext.Orders.ToList();
    }

    public void UpdateOrder(int id, Order _order)
    {
        var order = GetOrderById(id)!;

        order.ShippingStreetAddress = _order.ShippingStreetAddress;
        order.ShippingCity = _order.ShippingCity;
        order.ShippingState = _order.ShippingState;
        order.ShippingZipCode = _order.ShippingZipCode;
        order.PaymentMethod = _order.PaymentMethod;
        order.Total = _order.Total;
        order.Status = _order.Status;
        
        _gameStopContext.SaveChanges();
    }
}
