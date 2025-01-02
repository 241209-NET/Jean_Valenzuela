using GameStop.API.Data;
using GameStop.API.Model;
using Microsoft.EntityFrameworkCore;

namespace GameStop.API.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly GameStopContext _gameStopContext;
    public OrderRepository(GameStopContext gameStopContext) => _gameStopContext = gameStopContext;
    
    public Order CreateNewOrder(Order order, int[] games)
    {
        _gameStopContext.Order.Add(order);
        _gameStopContext.SaveChanges();

        foreach(int id in games){
            _gameStopContext.GameOrder.Add(new GameOrder(){
                GameId = id,
                OrderId = order.OrderId
            });
        }

        _gameStopContext.SaveChanges();
        return order;
    }

    public void DeleteOrderById(int id)
    {
        var order = GetOrderById(id);

        _gameStopContext.Order.Remove(order!);
        _gameStopContext.SaveChanges();
    }

    public Order? GetOrderById(int id)
    {
        var res = _gameStopContext.Order.Single( o => o.OrderId == id);

        _gameStopContext.Entry(res)
            .Collection(g => g.Games!)
            .Load();

        _gameStopContext.Entry(res)
            .Reference(a => a.Account)
            .Load();

        return res;
    }

    public IEnumerable<Order> GetOrders()
    {
        return _gameStopContext.Order
            .Include(g => g.Games)
            .Include(a => a.Account)
            .ToList();
    }

    public void UpdateOrder(int id, string Status)
    {
        var order = GetOrderById(id)!;

        order.Status = Status;
        
        _gameStopContext.SaveChanges();
    }
}
