using Microsoft.AspNetCore.Mvc;

namespace IF133.Tugas1.Api.Controllers;

[ApiController]
[Route("api/status")]
public sealed class StatusController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new
    {
        app = "IF133.Tugas1.Api",
        status = "running",
        time = DateTime.UtcNow
    });
}
