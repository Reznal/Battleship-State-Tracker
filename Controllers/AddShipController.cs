using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

[Route("[controller]")]
[ApiController]
public class AddShipController : ControllerBase
{
    /// <summary>
    /// Adds a ship to the players board
    /// </summary>
    /// <param name="Data"> test </param>
    /// <returns></returns>
    /// <response code="200"> Ship placed successfully </response>
    /// <response code="400"> Invalid Request </response>
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
    /// Direction ship is facing. 0 = Horizontal, 1 = Vertical.
    /// </summary>
    [Required]
    public ShipDirection ShipDirection { get; set; }

    /// <summary>
    /// Length of ship
    /// </summary>
    [Required]
    public int ShipLength { get; set; }

    /// <summary>
    /// X start position of ship
    /// </summary>
    [Required]
    public int X { get; set; }

    /// <summary>
    /// Y start position of ship
    /// </summary>
    [Required]
    public int Y { get; set;  }
}