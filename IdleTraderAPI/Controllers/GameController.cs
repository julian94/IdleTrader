using IdleEngine;
using IdleEngine.Model;
using Microsoft.AspNetCore.Mvc;

namespace IdleTraderAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController(ILogger<GameController> logger, Engine engine) : ControllerBase
{

    private readonly ILogger<GameController> _logger = logger;

    [HttpGet("state")]
    public IActionResult Get()
    {
        return new OkObjectResult(engine.GetUniverse());
    }
}
