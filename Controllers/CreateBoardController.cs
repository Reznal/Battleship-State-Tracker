using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

[assembly: Guid("be38f550-49d2-44d3-b0ea-3404419e4578")]

[Route("[controller]")]
[ApiController]
public class CreateBoardController : ControllerBase
{
    [HttpPost]
    public IActionResult Post(CreateBoardData data)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }

        CreateBoardReturnData returnData = new()
        {
            GameId = Game.instance.CreateGame()
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