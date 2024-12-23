using GameStop.API.Model;

namespace GameStop.API.Repository;

public interface IGameRepository
{
    Game CreateNewGame(Game game);
    IEnumerable<Game> GetGames();
    Game? GetGameById(int id);
    Game? UpdateGame(int id, Game game);
    void DeleteGameById(int id);
}