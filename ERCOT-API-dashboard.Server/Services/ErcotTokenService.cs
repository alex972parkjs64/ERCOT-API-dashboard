using ERCOT_API_dashboard.Server.Models;
using ERCOT_API_dashboard.Server.Services.Interface;

namespace ERCOT_API_dashboard.Server.Services
{
    public class ErcotTokenService : IErcotTokenService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _tokenUrlConfigKey = "ErcotApiUrls:Token";

        public ErcotTokenService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _configuration = configuration;
        }
        
        public async Task<ErcotApiTokenResponse> GetErcotApiTokenAsync(CancellationToken cancellationToken = default)
        {
            var authTokenParameters = new AuthTokenParameters(_configuration);
            var ercot_token_url = _configuration[_tokenUrlConfigKey];

            var token_url_with_params = string.Format(
                    "{0}{1}",
                    ercot_token_url,
                    authTokenParameters.UrlParameters);

            var tokenResponse = await _httpClient.PostAsync(token_url_with_params, null, cancellationToken);
            var ercotApiToken = await tokenResponse.Content.ReadFromJsonAsync<ErcotApiTokenResponse>(cancellationToken: cancellationToken);

            return ercotApiToken ?? new ErcotApiTokenResponse();
        }
    }
}
