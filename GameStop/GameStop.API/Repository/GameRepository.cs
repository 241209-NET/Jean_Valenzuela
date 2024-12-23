using GameStop.API.Data;
using GameStop.API.Model;

namespace GameStop.API.Repository;

public class GameRepository : IGameRepository
{
    private readonly GameStopContext _gameStopContext;
    public GameRepository(GameStopContext gameStopContext) => _gameStopContext = gameStopContext;
    
    public Game CreateNewGame(Game game)
    {
        _gameStopContext.Games.Add(game);
        _gameStopContext.SaveChanges();

        return game;
    }

    public void DeleteGameById(int id)
    {
        var game = GetGameById(id);
        _gameStopContext.Games.Remove(game!);
        _gameStopContext.SaveChanges();
    }

    public Game? GetGameById(int id)
    {
        return _gameStopContext.Games.Find(id);
    }

    public IEnumerable<Game> GetGames()
    {
        return _gameStopContext.Games.ToList();
    }

    public Game? UpdateGame(int id, Game _game)
    {
        var game = GetGameById(id);

        if (game is not null) _gameStopContext.Games.Update(_game);

        return game;
    }
}
