using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace GameStop.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;
    private readonly IReviewService _reviewService;
    public GameController(IGameService gameService, IReviewService reviewService)
    {
        _gameService = gameService;
        _reviewService = reviewService;
    }

    [HttpGet]
    public IActionResult GetGames()
    {
        var gameList = _gameService.GetGames();

        return Ok(gameList);
    }

    [HttpPost]
    public IActionResult CreateNewGame(GameDTO _game)
    {
        var game = _gameService.CreateNewGame(_game);

        return Ok(game);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGame(int id, GameDTO _game)
    {
        var game = _gameService.UpdateGame(id, _game);

        return Ok(game);
    }

    [HttpGet("{id}")]
    public IActionResult GetGameById(int id)
    {
        var game = _gameService.GetGameById(id);

        if (game is null) return NotFound();

        return Ok(game);
    }

    [HttpDelete]
    public IActionResult DeleteGameById(int id)
    {
        var game = _gameService.DeleteGameById(id);

        if (game is null) return NotFound();

        return Ok(game);
    }

    [HttpGet("{GameId}/reviews")]
    public IActionResult GetReviews(int GameId)
    {
        var reviews = _reviewService.GetReviews(GameId);

        return Ok(reviews);
    }
}