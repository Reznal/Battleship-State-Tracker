using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

[Route("[controller]")]
[ApiController]
public class AttackController : ControllerBase
{
    [HttpPost]
    public IActionResult Post(AttackData data)
    {
        //Check that request is valid
        if (!ModelState.IsValid)
            return BadRequest();

        GameSession gameSession = Game.instance.GetGameSession(data.GameId);

        //Return bad request if game doesnt exist
        if (gameSession == null)
            return BadRequest("Invalid Game Id");

        //Return bad request if player is not in this game
        if (!gameSession.PlayerExists(data.Id))
            return BadRequest("You are not in this game!");

        //Get opponents data
        Player player = data.Id == gameSession.Player1.Id ? gameSession.Player2 : gameSession.Player1;

        if (player.Attacked(data.X, data.Y))
            return Ok("hit");

        return Ok("miss");
    }
}

public class AttackData
{
    [Required]
    public int GameId { get; set; }

    [Required]
    public int Id { get; set; }

    [Required]
    public int X { get; set; }

    [Required]
    public int Y { get; set;  }
}