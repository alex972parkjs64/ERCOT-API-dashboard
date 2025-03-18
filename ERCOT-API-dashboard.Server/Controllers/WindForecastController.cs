using Microsoft.AspNetCore.Mvc;

using ERCOT_API_dashboard.Server.Models;
using ERCOT_API_dashboard.Server.Services.Interface;

namespace ERCOT_API_dashboard.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WindForecastController : ControllerBase
{
    private readonly ILogger<WindForecastController> _logger;
    private readonly IErcotTokenService _ercotTokenService;

    public WindForecastController(ILogger<WindForecastController> logger,
        IErcotTokenService ercotTokenService)
    {
        _logger = logger;
        _ercotTokenService = ercotTokenService;
    }

    [HttpGet(Name = "TestTokenAccess")]
    public async Task<IActionResult> GetToken()
    {        
        var tokenResult = await _ercotTokenService.GetErcotApiTokenAsync();

        return Ok(string.Empty);
    }

    // https://apiexplorer.ercot.com/api-details#api=pubapi-apim-api&operation=getData_hrly_sys_reg_wind_fcast_model
    //[HttpGet(Name = "system-wide/hourly/regional")]
    //public async Task<IActionResult> GetHourlySystemWideRegionalWindForecast()
    //{
    //    var authTokenParameters = new AuthTokenParameters(_config);

    //    var tokenResult = await _ercotTokenService.GetErcotApiTokenAsync(authTokenParameters);

    //    return Ok(string.Empty);
    //}

}
