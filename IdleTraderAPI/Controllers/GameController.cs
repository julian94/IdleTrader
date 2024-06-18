using IdleEngine;
using IdleEngine.Acting;
using IdleEngine.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

    [HttpPost("action")]
    public IActionResult AddAction(Dictionary<string, string> data)
    {
        IAction action = null;

        if (data.TryGetValue("type", out var type))
        {
            if (type == JumpAction.ActionName)
            {
                // TODO fill in actual values;
                action = new JumpAction(new ShipID(), new Position(0, 0));
            }
        }

        if (action != null && engine.TryDoAction(action))
        {
            return new OkObjectResult(action.ID);
        }
        else
        {
            return new StatusCodeResult(((int)HttpStatusCode.BadRequest));
        }
    }
}
