using ERCOT_API_dashboard.Server.Models.WindForecast;
using ERCOT_API_dashboard.Server.Services.Interface;

namespace ERCOT_API_dashboard.Server.Services
{
    public class EroctWindForecastService : IEroctWindForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _publicReportBaseUrl;
        private readonly string _publicReportUrlKey = "ErcotApiUrls:PublicReports";
        private readonly string _hourlyWindForecastReportUrl = "/np4-442-cd/hrly_sys_reg_wind_fcast_model";

        public EroctWindForecastService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _configuration = configuration;
            _publicReportBaseUrl = _configuration[_publicReportUrlKey] ?? throw new ArgumentNullException("public report url is not set");
        }

        public async Task<SystemWideHourlyRegionalResponse?> GetHourlySystemWideRegionalWindForecastByModel(SystemWideHourlyRegionalRequest param)
        {
            var reportParameters = param.UrlParameters;
            var reportUrl = string.Format("{0}{1}{2}", 
                    _publicReportBaseUrl, 
                    _hourlyWindForecastReportUrl, 
                    reportParameters);

            var windForecastResponse = await _httpClient.GetAsync(reportUrl);
            var wnidForecastResult   = await windForecastResponse.Content.ReadFromJsonAsync<SystemWideHourlyRegionalResponse>();

            return wnidForecastResult;
        }
    }
}
