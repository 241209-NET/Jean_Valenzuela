using GameStop.API.Model;

namespace GameStop.API.Service;

public interface IGameService
{
    Game CreateNewGame(Game game);
    IEnumerable<Game> GetGames();
    Game? GetGameById(int id);
    Game UpdateGame(int id, Game game);
    Game? DeleteGameById(int id);
}