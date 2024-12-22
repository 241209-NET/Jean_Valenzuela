using GameStop.API.Model;
using GameStop.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace GameStop.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly GameService _gameService;
    public GameController(GameService gameService) => _gameService = gameService;

    [HttpGet]
    public IActionResult GetGames()
    {
        var gameList = _gameService.GetGames();

        return Ok(gameList);
    }

    [HttpPost]
    public IActionResult CreateNewGame(Game _game)
    {
        var game = _gameService.CreateNewGame(_game);

        return Ok(game);
    }

    [HttpPut]
    public IActionResult UpdateGame(int id, Game _game)
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
}