using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

[Route("[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[ApiController]

public class AttackController : ControllerBase
{
    /// <summary>
    /// Sent by a player to attacked the opponents board
    /// </summary>
    /// <param name="Data"> test </param>
    /// <returns></returns>
    /// <response code="200"> Displays hit or miss </response>
    /// <response code="400"> Invalid Request </response>
    [HttpPost]
    public IActionResult Post(AttackData data)
    {
        //Check that request is valid
        if (!ModelState.IsValid)
            return BadRequest();

        GameSession gameSession = Game.Instance.GetGameSession(data.GameId);

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
    /// <summary>
    /// Id for game that player is in
    /// </summary>
    [Required]
    public int GameId { get; set; }

    /// <summary>
    /// Id for player
    /// </summary>
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// X position of attack
    /// </summary>
    [Required]
    public int X { get; set; }

    /// <summary>
    /// Y Position of attack
    /// </summary>
    [Required]
    public int Y { get; set;  }
}