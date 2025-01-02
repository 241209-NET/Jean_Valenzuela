using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Repository;
using GameStop.API.Utils;

namespace GameStop.API.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository) => _orderRepository = orderRepository;

    public OrderDTO CreateNewOrder(OrderDTO _order)
    {
        Order order = new();
        DTOToEntityRequest<OrderDTO, Order>.ToEntity(_order, order);

        var order_res = _orderRepository.CreateNewOrder(order, _order.GameId);

        OrderDTO res = new()
        {
            GameId = _order.GameId,
        };

        EntityToDTORequest<Order, OrderDTO>.ToDTO(order_res, res);

        return res;
    }

    public ResponseOrderDTO? DeleteOrderById(int id)
    {
        var order = GetOrderById(id);

        if (order is not null) _orderRepository.DeleteOrderById(id);

        return order;
    }

    public ResponseOrderDTO? GetOrderById(int id)
    {
        if (id < 1) return null;

        var order = _orderRepository.GetOrderById(id);

        ResponseOrderDTO res = new()
        {
            Games = [],
            Account = new()
        };

        EntityToDTORequest<Order, ResponseOrderDTO>.ToDTO(order!, res);

        foreach (Game game in order!.Games!)
        {
            GameDTO gameOrder = new();
            EntityToDTORequest<Game, GameDTO>.ToDTO(game, gameOrder);
            res.Games.Add(gameOrder);
        }

        EntityToDTORequest<Account, AccountDTO>.ToDTO(order.Account!, res.Account);

        return res;
    }

    public IEnumerable<ResponseOrderDTO> GetOrders()
    {
        var orders = _orderRepository.GetOrders();

        List<ResponseOrderDTO> res = [];

        foreach (Order order in orders)
        {
            ResponseOrderDTO dto = new()
            {
                Games = [],
                Account = new()
            };

            EntityToDTORequest<Order, ResponseOrderDTO>.ToDTO(order, dto);

            foreach (Game game in order.Games!)
            {
                GameDTO gameOrder = new();
                EntityToDTORequest<Game, GameDTO>.ToDTO(game, gameOrder);
                dto.Games.Add(gameOrder);
            }

            EntityToDTORequest<Account, AccountDTO>.ToDTO(order.Account!, dto.Account);

            res.Add(dto);
        }
        return res;
    }

    public ResponseOrderUpdateDTO? UpdateOrder(int id, string status)
    {
        var order = _orderRepository.GetOrderById(id);

        if (order is not null) _orderRepository.UpdateOrder(id, status);

        ResponseOrderUpdateDTO res = new();

        EntityToDTORequest<Order,ResponseOrderUpdateDTO>.ToDTO(order!, res);

        return res;
    }
}