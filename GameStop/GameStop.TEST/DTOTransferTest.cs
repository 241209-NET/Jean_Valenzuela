using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Utils;
using Newtonsoft.Json;

namespace GameStop.TEST.DTO;

public class DTOTransferTest
{
    [Fact]
    public void AccountToDTOTest()
    {
        Account account = new Account()
        {
            FirstName = "Jean",
            LastName = "Valenzuela",
            AccountId = 0,
            Email = "test@email.com",
            Password = "password",
            Age = 23,
            ZipCode = 48197,
            Street = "This Street",
            City = "This city",
            State = "This state"
        };

        AccountDTO expected = new()
        {
            FirstName = "Jean",
            LastName = "Valenzuela",
            Email = "test@email.com",
            Password = "password",
            Age = 23,
            ZipCode = 48197,
            Street = "This Street",
            City = "This city",
            State = "This state"
        };

        AccountDTO actual = new();

        EntityToDTORequest<Account, AccountDTO>.ToDTO(account, actual);

        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
    }

    [Fact]
    public void AccountDTOToEntityTest()
    {

        AccountDTO dto = new()
        {
            FirstName = "Jean",
            LastName = "Valenzuela",
            Email = "test@email.com",
            Password = "password",
            Age = 23,
            ZipCode = 48197,
            Street = "This Street",
            City = "This city",
            State = "This state"
        };

        Account expected = new()
        {
            FirstName = "Jean",
            LastName = "Valenzuela",
            Email = "test@email.com",
            Password = "password",
            Age = 23,
            ZipCode = 48197,
            Street = "This Street",
            City = "This city",
            State = "This state"
        };

        Account actual = new();

        DTOToEntityRequest<AccountDTO, Account>.ToEntity(dto, actual);

        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));

    }

    [Fact]
    public void GameToDTOTest()
    {
        Game game = new()
        {
            GameId = 12,
            Version = 123123123,
            Name = "Halo",
            Genre = "Shooting",
            Price = 59.99,
            Type = "Digital",
            ReleaseDate = DateOnly.MaxValue
        };

        GameDTO expected = new()
        {
            Version = 123123123,
            Name = "Halo",
            Genre = "Shooting",
            Price = 59.99,
            Type = "Digital",
            ReleaseDate = DateOnly.MaxValue
        };

        GameDTO actual = new();

        EntityToDTORequest<Game, GameDTO>.ToDTO(game, actual);

        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
    }

    [Fact]
    public void GameDTOToEntityTest()
    {

        GameDTO dto = new()
        {
            Version = 123123123,
            Name = "Halo",
            Genre = "Shooting",
            Price = 59.99,
            Type = "Digital",
            ReleaseDate = DateOnly.MaxValue
        };

        Game expected = new()
        {
            Version = 123123123,
            Name = "Halo",
            Genre = "Shooting",
            Price = 59.99,
            Type = "Digital",
            ReleaseDate = DateOnly.MaxValue
        };

        Game actual = new();

        DTOToEntityRequest<GameDTO, Game>.ToEntity(dto, actual);

        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));

    }

    [Fact]
    public void OrderToDTOTest()
    {
        Order order = new()
        {
            OrderId = 22,
            Status = "Pending",
            Total = 109.99,
            PaymentMethod = "Card",
            ShippingCity = "Some City",
            ShippingState = "Some State",
            ShippingStreetAddress = "Some Street",
            ShippingZipCode = "387123",
            AccountId = 12
        };

        OrderDTO expected = new()
        {
            Status = "Pending",
            Total = 109.99,
            PaymentMethod = "Card",
            ShippingCity = "Some City",
            ShippingState = "Some State",
            ShippingStreetAddress = "Some Street",
            ShippingZipCode = "387123",
            AccountId = 12,
            GameId = [1]
        };

        OrderDTO actual = new(){
            GameId = [1]
        };

        EntityToDTORequest<Order, OrderDTO>.ToDTO(order, actual);

        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
    }

    [Fact]
    public void OrderDTOToEntityTest()
    {

        OrderDTO dto = new()
        {
            Status = "Pending",
            Total = 109.99,
            PaymentMethod = "Card",
            ShippingCity = "Some City",
            ShippingState = "Some State",
            ShippingStreetAddress = "Some Street",
            ShippingZipCode = "387123",
            AccountId = 12,
            GameId = [1]
        };

        Order expected = new()
        {
            Status = "Pending",
            Total = 109.99,
            PaymentMethod = "Card",
            ShippingCity = "Some City",
            ShippingState = "Some State",
            ShippingStreetAddress = "Some Street",
            ShippingZipCode = "387123",
            AccountId = 12
        };

        Order actual = new();

        DTOToEntityRequest<OrderDTO, Order>.ToEntity(dto, actual);

        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));

    }

    [Fact]
    public void ReviewToDTOTest()
    {
        Review Review = new()
        {
            ReviewId = 123,
            Description = "Some Description",
            Date = DateOnly.MaxValue,
            Rating = 5,
            AccountId = 12,
            GameId = 14,
            Account = new Account
            {

            },
            Game = new Game{

            }
        };

        ReviewDTO expected = new()
        {
            Description = "Some Description",
            Date = DateOnly.MaxValue,
            Rating = 5
        };

        ReviewDTO actual = new();

        EntityToDTORequest<Review, ReviewDTO>.ToDTO(Review, actual);

        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
    }

    [Fact]
    public void ReviewDTOToEntityTest()
    {

        ReviewDTO dto = new()
        {
            Description = "Some Description",
            Date = DateOnly.MaxValue,
            Rating = 5
        };

        Review expected = new()
        {
            Description = "Some Description",
            Date = DateOnly.MaxValue,
            Rating = 5,
            Account = new Account
            {

            },
            Game = new Game{
                
            }
        };

        Review actual = new(){
            Account = new Account
            {

            },
            Game = new Game{
                
            }
        };

        DTOToEntityRequest<ReviewDTO, Review>.ToEntity(dto, actual);

        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));

    }

}