using GameStop.API.Data;
using GameStop.API.Model;

namespace GameStop.API.Repository;

public class GameRepository : IGameRepository
{
    private readonly GameStopContext _gameStopContext;
    public GameRepository(GameStopContext gameStopContext) => _gameStopContext = gameStopContext;
    
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
