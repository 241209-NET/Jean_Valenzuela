using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace GameStop.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService) => _orderService = orderService;

    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = _orderService.GetOrders();

        return Ok(orders);
    }

    [HttpPost]
    public IActionResult CreateNewOrder(OrderDTO _order)
    {
        var order = _orderService.CreateNewOrder(_order);

        return Ok(order);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrder(int id ,string status)
    {
        var order = _orderService.UpdateOrder(id, status);

        return Ok(order);
    }

    [HttpGet("{id}")]
    public IActionResult GetOrderById(int id)
    {
        var order = _orderService.GetOrderById(id);

        if (order is null) return NotFound();

        return Ok(order);
    }

    [HttpDelete]
    public IActionResult DeleteOrderById(int id)
    {
        var order = _orderService.DeleteOrderById(id);

        if(order is null) return NotFound();

        return Ok(order);
    }
}