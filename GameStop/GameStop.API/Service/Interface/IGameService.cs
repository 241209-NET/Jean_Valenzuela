using GameStop.API.DTO;
using GameStop.API.Model;

namespace GameStop.API.Service;

public interface IGameService
{
    GameDTO CreateNewGame(GameDTO game);
    IEnumerable<ResposeGameDTO> GetGames();
    ResposeGameDTO? GetGameById(int id);
    GameDTO? UpdateGame(int id, GameDTO game);
    ResposeGameDTO? DeleteGameById(int id);
}