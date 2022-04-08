using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

[Route("[controller]")]
[ApiController]
public class CreateBoardController : ControllerBase
{
    /// <summary>
    /// Creates a new game session with the requesting player.
    /// </summary>
    /// <returns></returns>
    /// <response code="200"> Returns the new games id </response>
    /// <response code="400"> Invalid Request </response>
    [HttpPost]
    public IActionResult Post(CreateBoardData data)
    {
        //Check that request is valid
        if(!ModelState.IsValid)
            return BadRequest();

        //Create player
        Player player = new Player(data.Id, data.Username);

        //Create game and return data
        CreateBoardReturnData returnData = new()
        {
            GameId = Game.instance.CreateGame(player)
        };

        return Ok(JsonConvert.SerializeObject(returnData));
    }
}

public class CreateBoardData
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }
}

public class CreateBoardReturnData
{
    public int GameId { get; set; }
}