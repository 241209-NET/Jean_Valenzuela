using GameStop.API.DTO;
using GameStop.API.Model;

namespace GameStop.API.Service;

public interface IGameService
{
    GameDTO CreateNewGame(GameDTO game);
    IEnumerable<ResponseGameDTO> GetGames();
    ResponseGameDTO? GetGameById(int id);
    GameDTO? UpdateGame(int id, GameDTO game);
    ResponseGameDTO? DeleteGameById(int id);
}