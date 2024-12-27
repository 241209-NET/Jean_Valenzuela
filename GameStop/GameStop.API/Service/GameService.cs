using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Repository;
using GameStop.API.Utils;

namespace GameStop.API.Service;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository) => _gameRepository = gameRepository;

    public Game CreateNewGame(GameDTO _game)
    {
        Game game = new();
        DTOToEntityRequest<GameDTO, Game>.ToEntity(_game, game);
        return _gameRepository.CreateNewGame(game);
    }

    public Game? DeleteGameById(int id)
    {
        var game = GetGameById(id);

        if (game is not null) _gameRepository.DeleteGameById(id);

        return game;
    }

    public Game? GetGameById(int id)
    {
        if (id < 1) return null;

        return _gameRepository.GetGameById(id);
    }

    public IEnumerable<Game> GetGames()
    {
        return _gameRepository.GetGames();
    }

    public Game? UpdateGame(int id, GameDTO _game)
    {
        var game = GetGameById(id);

        DTOToEntityRequest<GameDTO, Game>.ToEntity(_game,game!);

        if (game is not null) _gameRepository.UpdateGame(id, game);

        return game;
    }
}