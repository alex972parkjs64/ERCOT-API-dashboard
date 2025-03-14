using Microsoft.AspNetCore.Mvc;

using ERCOT_API_dashboard.Server.Models;
using ERCOT_API_dashboard.Server.Services.Interface;

namespace ERCOT_API_dashboard.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WindForecastController : ControllerBase
{
    private readonly ILogger<WindForecastController> _logger;
    private readonly IConfiguration _config;
    private readonly IErcotTokenService _ercotTokenService;

    public WindForecastController(ILogger<WindForecastController> logger,         
        IConfiguration config,
        IErcotTokenService ercotTokenService)
    {
        _logger = logger;
        _config = config;
        _ercotTokenService = ercotTokenService;
    }

    [HttpGet(Name = "TestTokenAccess")]
    public async Task<IActionResult> GetToken()
    {
        var authTokenParameters = new AuthTokenParameters(_config);

        var tokenResult = await _ercotTokenService.GetErcotApiTokenAsync(authTokenParameters);

        return Ok(string.Empty);
    }
}
