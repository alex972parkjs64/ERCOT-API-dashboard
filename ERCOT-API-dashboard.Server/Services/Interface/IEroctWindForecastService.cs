using ERCOT_API_dashboard.Server.Models.WindForecast;

namespace ERCOT_API_dashboard.Server.Services.Interface
{
    public interface IEroctWindForecastService
    {
        Task<SystemWideHourlyRegionalResponse?> GetHourlySystemWideRegionalWindForecastByModel(SystemWideHourlyRegionalRequest param, string accessToken);
    }
}
