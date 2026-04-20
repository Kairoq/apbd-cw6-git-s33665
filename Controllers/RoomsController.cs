using Microsoft.AspNetCore.Mvc;
using apbd_cw5_git_s33665.Model;

namespace apbd_cw5_git_s33665.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllRooms()
    {
        return(Ok(Data.Rooms));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetRoomById(int id)
    {
        var room = Data.Rooms.FirstOrDefault(r => r.Id == id);
        if  (room == null)
        {
            return NotFound($"Room {id} not found");
        }
        return Ok(room);
    }

    [HttpGet("building/{buildingCode}")]
    public IActionResult GetRoomsByBuildingCode(string buildingCode)
    {
        var rooms = Data.Rooms.
            Where(r => r.BuildingCode.Equals(buildingCode, StringComparison.OrdinalIgnoreCase))
            .ToList();
        return Ok(rooms);
    }
}