using GameStop.API.DTO;
using GameStop.API.Model;

namespace GameStop.API.Service;

public interface IOrderService
{
    OrderDTO CreateNewOrder(OrderDTO order);
    IEnumerable<ResponseOrderDTO> GetOrders();
    ResponseOrderDTO? GetOrderById(int id);
    ResponseOrderUpdateDTO? UpdateOrder(int id, string status);
    ResponseOrderDTO? DeleteOrderById(int id);
}