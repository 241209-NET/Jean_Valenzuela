using GameStop.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace GameStop.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly GameService _gameService;
    public GameController(GameService gameService) => _gameService = gameService;
}