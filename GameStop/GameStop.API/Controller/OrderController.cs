using GameStop.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace GameStop.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService) => _orderService = orderService;
}