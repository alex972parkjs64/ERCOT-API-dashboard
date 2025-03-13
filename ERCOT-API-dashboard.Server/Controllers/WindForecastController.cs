using Microsoft.AspNetCore.Mvc;

namespace ERCOT_API_dashboard.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WindForecastController : ControllerBase
{
    private readonly ILogger<WindForecastController> _logger;

    public WindForecastController(ILogger<WindForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        return Ok(string.Empty);
    }
}
