using Microsoft.AspNetCore.Mvc;

using ERCOT_API_dashboard.Server.Services.Interface;
using ERCOT_API_dashboard.Server.Models.WindForecast;

namespace ERCOT_API_dashboard.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WindForecastController : ControllerBase
{
    private readonly ILogger<WindForecastController> _logger;
    private readonly IErcotTokenService _ercotTokenService;
    private readonly IEroctWindForecastService _eroctWindForecastService;

    public WindForecastController(ILogger<WindForecastController> logger,
        IErcotTokenService ercotTokenService,
        IEroctWindForecastService eroctWindForecastService)
    {
        _logger = logger;
        _ercotTokenService = ercotTokenService;
        _eroctWindForecastService = eroctWindForecastService;
    }
    
    // https://apiexplorer.ercot.com/api-details#api=pubapi-apim-api&operation=getData_hrly_sys_reg_wind_fcast_model
    [HttpGet]
    [Route("system-wide/hourly/regional")]
    public async Task<IActionResult> GetHourlySystemWideRegionalWindForecast()
    {
        var tokenResult = await _ercotTokenService.GetErcotApiTokenAsync();

        // Note : for now, hard-coding datetime for development purpose
        // TODO : replace with api parameter !
        var param = new SystemWideHourlyRegionalRequest(new DateTime(2025, 3, 5, 13, 0, 0));

        var windForecastResult =
            await _eroctWindForecastService.GetHourlySystemWideRegionalWindForecastByModel(
                    param,
                    tokenResult.access_token);

        return Ok(windForecastResult);
    }

}
