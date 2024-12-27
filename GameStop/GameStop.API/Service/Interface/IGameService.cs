using GameStop.API.DTO;
using GameStop.API.Model;

namespace GameStop.API.Service;

public interface IGameService
{
    Game CreateNewGame(GameDTO game);
    IEnumerable<Game> GetGames();
    Game? GetGameById(int id);
    Game? UpdateGame(int id, GameDTO game);
    Game? DeleteGameById(int id);
}