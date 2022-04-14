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
            GameId = Game.Instance.CreateGame(player)
        };

        return Ok(JsonConvert.SerializeObject(returnData));
    }
}

public class CreateBoardData
{
    ///<summary>
    ///Id for sending player
    /// </summary>
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Username for sending player
    /// </summary>
    [Required]
    public string Username { get; set; }
}

public class CreateBoardReturnData
{
    /// <summary>
    /// Gameid for game session that has been created
    /// </summary>
    public int GameId { get; set; }
}