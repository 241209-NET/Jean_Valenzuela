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
            new Game { GameId = 1, Version = 1134234},
            new Game { GameId = 2, Version = 2434121},
            new Game { GameId = 3, Version = 7546535},
            new Game { GameId = 4, Version = 5467435},
            new Game { GameId = 5, Version = 3456756},
        ];

        mockRepository.Setup(x => x.GetGames()).Returns(games);

        var result = gameService.GetGames();

        Assert.Equal(JsonConvert.SerializeObject(games), JsonConvert.SerializeObject(result));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void GetGamesByIdTest(int GameId)
    {
        Mock<IGameRepository> mockRepository = new();
        GameService gameService = new(mockRepository.Object);

        List<Game> games = [
            new Game { GameId = 1, Version = 1134234},
            new Game { GameId = 2, Version = 2434121},
            new Game { GameId = 3, Version = 7546535},
            new Game { GameId = 4, Version = 5467435},
            new Game { GameId = 5, Version = 3456756},
        ];

        Game actual = games.Find(g => g.GameId == GameId)!;

        mockRepository.Setup(x => x.GetGameById(GameId)).Returns(games.FirstOrDefault(g => g.GameId == GameId));

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
    [InlineData(1)]
    public void DeleteGamesByIdTest(int GameId)
    {
        Mock<IGameRepository> mockRepository = new();
        GameService gameService = new(mockRepository.Object);

        List<Game> games = [
            new Game { GameId = 1, Version = 1134234},
            new Game { GameId = 2, Version = 2434121},
            new Game { GameId = 3, Version = 7546535},
        ];

        mockRepository.Setup(x => x.GetGameById(GameId)).Returns(games.FirstOrDefault(g => g.GameId == GameId));

        gameService.DeleteGameById(GameId);
        
        mockRepository.Verify(x => x.DeleteGameById(GameId), Times.Once());
    }

    [Fact]
    public void CreateGameTest()
    {
        Mock<IGameRepository> mockRepository = new();
        GameService gameService = new(mockRepository.Object);

        GameDTO gameDTO = new ();

        gameService.CreateNewGame(gameDTO);

        mockRepository.Verify(x => x.CreateNewGame(It.IsAny<Game>()), Times.Once());
    }

    [Theory]
    [InlineData(1)]
    public void UpdateGameTest(int GameId)
    {
        Mock<IGameRepository> mockRepository = new();
        GameService gameService = new(mockRepository.Object);

        GameDTO gameDto = new ();

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