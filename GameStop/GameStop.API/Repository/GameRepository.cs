using GameStop.API.Data;
using GameStop.API.Model;
using Microsoft.EntityFrameworkCore;

namespace GameStop.API.Repository;

public class GameRepository : IGameRepository
{
    private readonly GameStopContext _gameStopContext;
    public GameRepository(GameStopContext gameStopContext) => _gameStopContext = gameStopContext;

    public Game CreateNewGame(Game game)
    {
        _gameStopContext.Game.Add(game);
        _gameStopContext.SaveChanges();

        return game;
    }

    public void DeleteGameById(int id)
    {
        var game = GetGameById(id);
        _gameStopContext.Game.Remove(game!);
        _gameStopContext.SaveChanges();
    }

    public Game? GetGameById(int id)
    {
        var res = _gameStopContext.Game.Single(g => g.GameId == id);

        _gameStopContext.Entry(res)
            .Collection(r => r.Reviews!)
            .Load();

        return res;
    }

    public IEnumerable<Game> GetGames()
    {
        return _gameStopContext.Game
            .Include(r => r.Reviews)
            .ToList();
    }

    public void UpdateGame(int id, Game _game)
    {
        var game = GetGameById(id)!;

        game.Price = _game.Price;
        game.ReleaseDate = _game.ReleaseDate;
        game.Name = _game.Name;
        game.Genre = _game.Genre;
        game.Version = _game.Version;

        _gameStopContext.SaveChanges();
    }
}
