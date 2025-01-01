using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Repository;
using GameStop.API.Service;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Moq;
using Newtonsoft.Json;

namespace GameStop.TEST.Service;

public class OrderServiceTest
{
    [Fact]
    public void GetOrdersTest()
    {
        Mock<IOrderRepository> mockRepo = new();
        OrderService orderService = new(mockRepo.Object);

        List<Order> orders = [
            new Order { OrderId = 1, Total = 30.99, AccountId = 2},
            new Order { OrderId = 2, Total = 35.99, AccountId = 2},
            new Order { OrderId = 3, Total = 32.99, AccountId = 2}
        ];

        mockRepo.Setup(x => x.GetOrders()).Returns(orders);

        var result = orderService.GetOrders();

        Assert.Equal(JsonConvert.SerializeObject(orders), JsonConvert.SerializeObject(result));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void GetOrderByIdTest(int OrderId)
    {
        Mock<IOrderRepository> mockRepo = new();
        OrderService orderService = new(mockRepo.Object);

        List<Order> orders = [
            new Order { OrderId = 1, Total = 30.99, AccountId = 2},
            new Order { OrderId = 2, Total = 35.99, AccountId = 2},
            new Order { OrderId = 3, Total = 32.99, AccountId = 2}
        ];

        Order actual = orders.FirstOrDefault(o => o.OrderId == OrderId)!;

        mockRepo.Setup(x => x.GetOrderById(OrderId)).Returns(orders.FirstOrDefault(o => o.OrderId == OrderId));

        var result = orderService.GetOrderById(OrderId);

        if (result == null)
        {
            Assert.Null(result);
        }
        else
        {
            Assert.Equal(JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(result));
        }
    }

    [Fact]
    public void DeleteOrderByIdTest()
    {
        Mock<IOrderRepository> mockRepo = new();
        OrderService orderService = new(mockRepo.Object);

        Order actual = new() { OrderId = 1, Total = 30.99, AccountId = 2 };

        mockRepo.Setup(x => x.GetOrderById(actual.OrderId)).Returns(actual);

        orderService.DeleteOrderById(actual.OrderId);

        mockRepo.Verify(x => x.DeleteOrderById(actual.OrderId));
    }

    [Fact]
    public void CreateNewOrderTest()
    {
        Mock<IOrderRepository> mockRepo = new();
        OrderService orderService = new(mockRepo.Object);

        OrderDTO order = new() { Total = 40.99, GameId = [1, 2, 3] };

        orderService.CreateNewOrder(order);

        mockRepo.Verify(x => x.CreateNewOrder(It.IsAny<Order>(), order.GameId), Times.Once());
    }

    [Fact]
    public void UpdateOrderTest()
    {
        Mock<IOrderRepository> mockRepo = new();
        OrderService orderService = new(mockRepo.Object);

        Order order = new() { OrderId = 1};

        int OrderId = order.OrderId;

        mockRepo.Setup(x => x.GetOrderById(OrderId)).Returns(order);

        orderService.UpdateOrder(OrderId, "Completed");

        mockRepo.Verify(x => x.UpdateOrder(OrderId, It.IsAny<String>()), Times.Once());
    }
}