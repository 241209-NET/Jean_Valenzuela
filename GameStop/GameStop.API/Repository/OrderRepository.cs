using GameStop.API.Data;
using GameStop.API.Model;

namespace GameStop.API.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly GameStopContext _gameStopContext;
    public OrderRepository(GameStopContext gameStopContext) => _gameStopContext = gameStopContext;
    
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
