using GameStop.API.Model;
using GameStop.API.Repository;

namespace GameStop.API.Service;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository) => _gameRepository = gameRepository;

    public Game CreateNewGame(Game game)
    {
        throw new NotImplementedException();
    }

    public Game DeleteGameById(int id)
    {
        throw new NotImplementedException();
    }

    public Game GetGameById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Game> GetGames()
    {
        throw new NotImplementedException();
    }

    public Game UpdateGame(int id, Game game)
    {
        throw new NotImplementedException();
    }
}