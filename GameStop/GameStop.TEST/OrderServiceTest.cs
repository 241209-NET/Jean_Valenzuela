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
            new Order{
                OrderId = 1,
                Status = "String",
                Games = [
                    new Game{
                        GameId = 1,
                        Version = 2
                    }
                ],
                Account = new Account{
                    AccountId = 1,
                    LastName = "String"
                }
            }
        ];

        List<ResponseOrderDTO> dto = [
            new ResponseOrderDTO{
                OrderId = 1,
                Status = "String",
                Games = [
                    new GameDTO{
                        Version = 2
                    }
                ],
                Account = new AccountDTO{
                    LastName = "String"
                }
            }
        ];

        mockRepo.Setup(x => x.GetOrders()).Returns(orders);

        var result = orderService.GetOrders();

        Assert.Equal(JsonConvert.SerializeObject(dto), JsonConvert.SerializeObject(result));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void GetOrderByIdTest(int OrderId)
    {
        Mock<IOrderRepository> mockRepo = new();
        OrderService orderService = new(mockRepo.Object);

        Order input = new()
        {
            OrderId = 1,
            Status = "String",
            Games = [
                    new Game{
                        GameId = 1,
                        Version = 2
                    }
                ],
            Account = new Account
            {
                AccountId = 1,
                LastName = "String"
            }
        };

        ResponseOrderDTO expected = new()
        {
            OrderId = 1,
            Status = "String",
            Games = [
                    new GameDTO{
                        Version = 2
                    }
                ],
            Account = new AccountDTO
            {
                LastName = "String"
            }
        };


        mockRepo.Setup(x => x.GetOrderById(OrderId)).Returns(input);

        var result = orderService.GetOrderById(OrderId);

        if (result == null)
        {
            Assert.Null(result);
        }
        else
        {
            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(result));
        }
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void DeleteOrderByIdTest(int OrderId)
    {
        Mock<IOrderRepository> mockRepo = new();
        OrderService orderService = new(mockRepo.Object);

        Order input = new()
        {
            OrderId = 1,
            Status = "String",
            Games = [
                    new Game{
                        GameId = 1,
                        Version = 2
                    }
                ],
            Account = new Account
            {
                AccountId = 1,
                LastName = "String"
            }
        };

        ResponseOrderDTO expected = new()
        {
            OrderId = 1,
            Status = "String",
            Games = [
                    new GameDTO{
                        Version = 2
                    }
                ],
            Account = new AccountDTO
            {
                LastName = "String"
            }
        };

        mockRepo.Setup(x => x.GetOrderById(OrderId)).Returns(input);

        var result = orderService.DeleteOrderById(OrderId);

        if(OrderId == 0)
        {
            Assert.Null(result);
        }
        else
        {
            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(result));
        }
    }

    [Fact]
    public void CreateNewOrderTest()
    {
        Mock<IOrderRepository> mockRepo = new();
        OrderService orderService = new(mockRepo.Object);

        OrderDTO order = new() { Total = 40.99, GameId = [1, 2, 3] };

        Order input = new() {Total = 40.99};

        mockRepo.Setup(x => x.CreateNewOrder(It.IsAny<Order>(), order.GameId)).Returns(input);

        var result = orderService.CreateNewOrder(order);

        Assert.Equal(JsonConvert.SerializeObject(order), JsonConvert.SerializeObject(result));
    }

    [Fact]
    public void UpdateOrderTest()
    {
        Mock<IOrderRepository> mockRepo = new();
        OrderService orderService = new(mockRepo.Object);

        Order order = new() { OrderId = 1 };

        int OrderId = order.OrderId;

        mockRepo.Setup(x => x.GetOrderById(OrderId)).Returns(order);

        orderService.UpdateOrder(OrderId, "Completed");

        mockRepo.Verify(x => x.UpdateOrder(OrderId, It.IsAny<String>()), Times.Once());
    }
}