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

    [HttpGet("filter")]
    public IActionResult GetFilteredRooms(int? minCapacity, bool? hasProjector, bool? activeOnly)
    {
        var query = Data.Rooms.AsQueryable();

        if (minCapacity.HasValue)
            query = query.Where(r => r.Capacity >= minCapacity.Value);

        if (hasProjector.HasValue)
            query = query.Where(r => r.HasProjector == hasProjector.Value);

        if (activeOnly.HasValue && activeOnly.Value)
            query = query.Where(r => r.IsActive == true);

        return Ok(query.ToList());
    }

    [HttpPost]
    public IActionResult CreateRoom(Room newRoom)
    {
        newRoom.Id = Data.Rooms.Max(r => r.Id) + 1;
        Data.Rooms.Add(newRoom);
        return CreatedAtAction(nameof(GetRoomById), new { id = newRoom.Id }, newRoom);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateRoom(int id, Room updatedRoom)
    {
        var existingRoom = Data.Rooms.FirstOrDefault(r => r.Id == id);
        if (existingRoom == null)
        {
            return NotFound();
        }
        
        existingRoom.Name = updatedRoom.Name;
        existingRoom.BuildingCode = updatedRoom.BuildingCode;
        existingRoom.Floor = updatedRoom.Floor;
        existingRoom.Capacity = updatedRoom.Capacity;
        existingRoom.HasProjector = updatedRoom.HasProjector;
        existingRoom.IsActive = updatedRoom.IsActive;
        
        return Ok(existingRoom);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteRoom(int id)
    {
        var room = Data.Rooms.FirstOrDefault(r => r.Id == id);
        if (room == null)
        {
            return NotFound();
        }
        bool hasReservation = Data.Reservations.Any(r => r.RoomId == id);
        if (hasReservation)
        {
            return Conflict($"Room {id} has reservation");
        }
        Data.Rooms.Remove(room);
        return NoContent();
    }
}