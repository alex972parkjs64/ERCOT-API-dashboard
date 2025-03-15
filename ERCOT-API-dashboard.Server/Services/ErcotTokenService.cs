using ERCOT_API_dashboard.Server.Models;
using ERCOT_API_dashboard.Server.Services.Interface;

namespace ERCOT_API_dashboard.Server.Services
{
    public class ErcotTokenService : IErcotTokenService
    {
        private readonly HttpClient _httpClient;
        private readonly string _ercot_token_url = "https://ercotb2c.b2clogin.com/ercotb2c.onmicrosoft.com/B2C_1_PUBAPI-ROPC-FLOW/oauth2/v2.0/token?";

        public ErcotTokenService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<ErcotApiTokenResponse> GetErcotApiTokenAsync(AuthTokenParameters authTokenParameters, CancellationToken cancellationToken = default)
        {
            var token_url_with_params = string.Format("{0}{1}",  
                    _ercot_token_url,
                    authTokenParameters.TokenUrlParameters);

            var tokenResponse = await _httpClient.PostAsync(token_url_with_params, null, cancellationToken);
            var ercotApiToken = await tokenResponse.Content.ReadFromJsonAsync<ErcotApiTokenResponse>(cancellationToken: cancellationToken);

            return ercotApiToken ?? new ErcotApiTokenResponse();
        }
    }
}
