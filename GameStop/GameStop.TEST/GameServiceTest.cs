using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Repository;
using GameStop.API.Service;
using Moq;
using Newtonsoft.Json;

namespace GameStop.TEST.Service;

public class GameServiceTest
{
    [Fact]
    public void GetGamesTest()
    {
        Mock<IGameRepository> mockRepository = new();
        GameService gameService = new(mockRepository.Object);

        List<Game> games = [
            new Game{
                GameId = 1,
                Version = 12343,
                Name = "String",
                Genre = "String",
                Price = 12.32,
                Type = "String",
                ReleaseDate = DateOnly.MaxValue,
                Orders = [
                    new Order{
                        OrderId= 1,
                        Status= "Complete",
                        Total= 149.99,
                        PaymentMethod= "Card",
                        ShippingZipCode= "48197",
                        ShippingStreetAddress= "This Address",
                        ShippingCity= "This City",
                        ShippingState= "This State",
                        AccountId= 1,
                        Games= null,
                        Account= null
                    }
                ],
                Reviews = [
                    new Review{
                        ReviewId = 1,
                        Description = "String",
                        Date = DateOnly.MaxValue,
                        Rating = 4,
                        AccountId = 1,
                        GameId = 1,
                        Account = null,
                        Game = null
                    }
                ]
            }
        ];

        List<ResponseGameDTO> Expected = [
            new ResponseGameDTO{
                GameId = 1,
                Version = 12343,
                Name = "String",
                Genre = "String",
                Price = 12.32,
                Type = "String",
                ReleaseDate = DateOnly.MaxValue,
                Reviews = [
                    new ReviewDTO{
                        Description = "String",
                        Date = DateOnly.MaxValue,
                        Rating = 4
                    }
                ]
            }
        ];



        mockRepository.Setup(x => x.GetGames()).Returns(games);

        var result = gameService.GetGames();

        Assert.Equal(JsonConvert.SerializeObject(Expected), JsonConvert.SerializeObject(result));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void GetGamesByIdTest(int GameId)
    {
        Mock<IGameRepository> mockRepository = new();
        GameService gameService = new(mockRepository.Object);

        Game input = new()
        {
            GameId = 1,
            Version = 12343,
            Name = "String",
            Genre = "String",
            Price = 12.32,
            Type = "String",
            ReleaseDate = DateOnly.MaxValue,
            Orders = [
                     new Order{
                        OrderId= 1,
                        Status= "Complete",
                        Total= 149.99,
                        PaymentMethod= "Card",
                        ShippingZipCode= "48197",
                        ShippingStreetAddress= "This Address",
                        ShippingCity= "This City",
                        ShippingState= "This State",
                        AccountId= 1,
                        Games= null,
                        Account= null
                    }
                 ],
            Reviews = [
                     new Review{
                        ReviewId = 1,
                        Description = "String",
                        Date = DateOnly.MaxValue,
                        Rating = 4,
                        AccountId = 1,
                        GameId = 1,
                        Account = null,
                        Game = null
                    }
                 ]
        };

        ResponseGameDTO actual = new()
        {
            GameId = 1,
            Version = 12343,
            Name = "String",
            Genre = "String",
            Price = 12.32,
            Type = "String",
            ReleaseDate = DateOnly.MaxValue,
            Reviews = [
                    new ReviewDTO{
                        Description = "String",
                        Date = DateOnly.MaxValue,
                        Rating = 4
                    }
                ]
        };

        mockRepository.Setup(x => x.GetGameById(GameId)).Returns(input);

        var result = gameService.GetGameById(GameId);

        if (GameId == 0)
        {
            Assert.Null(result);
        }
        else
        {
            Assert.Equal(JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(result));
        }
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void DeleteGamesByIdTest(int GameId)
    {
        Mock<IGameRepository> mockRepository = new();
        GameService gameService = new(mockRepository.Object);

        Game input = new(){Version = 1131234, Reviews = []};

        ResponseGameDTO expected = new(){Version = 1131234, Reviews = []};

        mockRepository.Setup(x => x.GetGameById(GameId)).Returns(input);

        var result = gameService.DeleteGameById(GameId);

         if(GameId == 0)
        {
            Assert.Null(result);
        }
        else
        {
            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(result));
        }
    }

    [Fact]
    public void CreateGameTest()
    {
        Mock<IGameRepository> mockRepository = new();
        GameService gameService = new(mockRepository.Object);

        GameDTO game = new() { Version = 123423 };
        Game input = new() { Version = 123423 };

        mockRepository.Setup(x => x.CreateNewGame(It.IsAny<Game>())).Returns(input);

        var result = gameService.CreateNewGame(game);

        Assert.Equal(JsonConvert.SerializeObject(game), JsonConvert.SerializeObject(result));
    }

    [Theory]
    [InlineData(1)]
    public void UpdateGameTest(int GameId)
    {
        Mock<IGameRepository> mockRepository = new();
        GameService gameService = new(mockRepository.Object);

        GameDTO gameDto = new();

        List<Game> games = [
            new Game { GameId = 1, Version = 1134234},
            new Game { GameId = 2, Version = 2434121},
            new Game { GameId = 3, Version = 7546535},
        ];

        mockRepository.Setup(x => x.GetGameById(GameId)).Returns(games.FirstOrDefault(g => g.GameId == GameId));

        gameService.UpdateGame(GameId, gameDto);

        mockRepository.Verify(x => x.UpdateGame(GameId, It.IsAny<Game>()), Times.Once());
    }
}