﻿using System.Net.Http.Headers;

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
        private readonly string _apiSubscriptionKey;
        private readonly string _apiSubscriptionKey_Key = "token:api_subscription_key";
        private readonly string _httpHeaderKeyForApimSubKey = "Ocp-Apim-Subscription-Key";      // TODO : might include in secret also
        private readonly string _hourlyWindForecastReportUrl = "/np4-442-cd/hrly_sys_reg_wind_fcast_model";

        public EroctWindForecastService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _configuration = configuration;
            _publicReportBaseUrl = _configuration[_publicReportUrlKey] ?? throw new ArgumentNullException("public report url is not set");
            _apiSubscriptionKey  = _configuration[_apiSubscriptionKey_Key] ?? throw new ArgumentNullException("api subscription key not found");
        }

        public async Task<SystemWideHourlyRegionalResponse?> GetHourlySystemWideRegionalWindForecastByModel(SystemWideHourlyRegionalRequest param, string accessToken)
        {
            var reportParameters = param.UrlParameters;
            var reportUrl = string.Format("{0}{1}{2}", 
                    _publicReportBaseUrl, 
                    _hourlyWindForecastReportUrl, 
                    reportParameters);            

            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", accessToken);

            _httpClient.DefaultRequestHeaders.Add(_httpHeaderKeyForApimSubKey, _apiSubscriptionKey);

            var windForecastResponse = await _httpClient.GetAsync(reportUrl);
            var windForecastResult   = await windForecastResponse.Content.ReadFromJsonAsync<SystemWideHourlyRegionalResponse>();

            windForecastResult?.MapRawWindForecastData();

            return windForecastResult;
        }
    }
}
