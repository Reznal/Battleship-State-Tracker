using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

[Route("[controller]")]
[ApiController]
public class AddShipController : ControllerBase
{
    [HttpPost]
    public IActionResult Post(AddShipData data)
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

        //Get players data
        Player player = data.Id == gameSession.Player1.Id ? gameSession.Player1 : gameSession.Player2;
        Ship ship = new Ship(data.ShipLength, data.ShipDirection, player);


        //If player can place ship, return ok
        if (player.PlaceShip(ship, data.X, data.Y))
            return Ok();
        else //Return bad request
            return BadRequest("Unable to place ship");
    }
}

public class AddShipData
{
    [Required]
    public int GameId { get; set; }

    [Required]
    public int Id { get; set; }

    [Required]
    public ShipDirection ShipDirection { get; set; }

    [Required]
    public int ShipLength { get; set; }

    [Required]
    public int X { get; set; }

    [Required]
    public int Y { get; set;  }
}