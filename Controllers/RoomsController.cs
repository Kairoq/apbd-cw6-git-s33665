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
}