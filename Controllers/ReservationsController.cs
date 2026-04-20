using Microsoft.AspNetCore.Mvc;
using apbd_cw5_git_s33665.Model;

namespace apbd_cw5_git_s33665.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetReservations(DateOnly? date, string? status, int? roomId)
    {
        var query = Data.Reservations.AsQueryable();

        if (date.HasValue) query = query.Where(r => r.Date == date);
        if (!string.IsNullOrEmpty(status)) query = query.Where(r => r.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
        if (roomId.HasValue) query = query.Where(r => r.RoomId == roomId);

        return Ok(query.ToList());
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetReservationById(int id)
    {
        var res = Data.Reservations.FirstOrDefault(r => r.Id == id);
    
        if (res == null)
        {
            return NotFound($"Reservation with ID {id} not found.");
        }
    
        return Ok(res);
    }
    
    [HttpPost]
    public IActionResult Post(Reservation newReservation)
    {
        var room = Data.Rooms.FirstOrDefault(r => r.Id == newReservation.RoomId);
        if (room == null)
        {
            return NotFound("Room not found");
        }

        if (room.IsActive == false)
        {
            return BadRequest("Room is inactive");
        }

        bool isOverlaping = Data.Reservations.Any(r =>
            r.RoomId == newReservation.Id
            && r.Date == newReservation.Date
            && newReservation.StartTime < r.StartTime
            && newReservation.EndTime > r.EndTime);

        if (isOverlaping)
        {
            return Conflict("Reservation overlap");
        }
        
        newReservation.Id = Data.Reservations.Max(r => r.Id) + 1;
        Data.Reservations.Add(newReservation);

        return CreatedAtAction(nameof(GetReservationById), new { id = newReservation.Id }, newReservation);
    }
}