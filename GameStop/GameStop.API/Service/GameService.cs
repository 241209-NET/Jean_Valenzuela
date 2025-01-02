using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Repository;
using GameStop.API.Utils;

namespace GameStop.API.Service;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository) => _gameRepository = gameRepository;

    public GameDTO CreateNewGame(GameDTO _game)
    {
        Game game = new();
        DTOToEntityRequest<GameDTO, Game>.ToEntity(_game, game);

        var game_res = _gameRepository.CreateNewGame(game);

        GameDTO res = new ();

        EntityToDTORequest<Game, GameDTO>.ToDTO(game_res,res);

        return res;
    }

    public ResposeGameDTO? DeleteGameById(int id)
    {
        var game = GetGameById(id);

        if (game is not null) _gameRepository.DeleteGameById(id);

        return game;
    }

    public ResposeGameDTO? GetGameById(int id)
    {
        if (id < 1) return null;

        var game = _gameRepository.GetGameById(id);

        ResposeGameDTO res = new()
        {
            Reviews = []
        };

        EntityToDTORequest<Game, ResposeGameDTO>.ToDTO(game!, res);

        foreach(Review review in game!.Reviews!)
        {
            ReviewDTO gameReview = new();
            EntityToDTORequest<Review, ReviewDTO>.ToDTO(review, gameReview);
            res.Reviews.Add(gameReview);
        }

        return res;
    }

    public IEnumerable<ResposeGameDTO> GetGames()
    {
        var games = _gameRepository.GetGames();

        List<ResposeGameDTO> res = [];

        foreach (Game game in games)
        {
            ResposeGameDTO dto = new() 
            {
                Reviews = []
            };

            EntityToDTORequest<Game, ResposeGameDTO>.ToDTO(game, dto);

            foreach ( Review review in game.Reviews!)
            {
                ReviewDTO gameReview = new();
                EntityToDTORequest<Review, ReviewDTO>.ToDTO(review, gameReview);
                dto.Reviews.Add(gameReview);
            }

            res.Add(dto);
        }
        return res;
    }

    public GameDTO? UpdateGame(int id, GameDTO _game)
    {
        var game =_gameRepository.GetGameById(id);

        DTOToEntityRequest<GameDTO, Game>.ToEntity(_game, game!);

        if (game is not null) _gameRepository.UpdateGame(id, game);

        GameDTO res = new();

        EntityToDTORequest<Game, GameDTO>.ToDTO(game!,res);

        return res;
    }
}