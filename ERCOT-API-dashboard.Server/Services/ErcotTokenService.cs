using Microsoft.Extensions.Caching.Memory;

using ERCOT_API_dashboard.Server.Models;
using ERCOT_API_dashboard.Server.Services.Interface;

namespace ERCOT_API_dashboard.Server.Services
{
    public class ErcotTokenService : IErcotTokenService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _tokenUrlConfigKey = "ErcotApiUrls:Token";
        private readonly string _tokenCacheKey = "tokenCacheKey";

        public ErcotTokenService(HttpClient httpClient, IConfiguration configuration, IMemoryCache memoryCache)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _configuration = configuration;
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(IMemoryCache));
        }
        
        public async Task<ErcotApiTokenResponse> GetErcotApiTokenAsync(CancellationToken cancellationToken = default)
        {
            if (!_memoryCache.TryGetValue(_tokenCacheKey, out ErcotApiTokenResponse? ercotApiToken))
            {
                var authTokenParameters = new AuthTokenParameters(_configuration);
                var ercot_token_url = _configuration[_tokenUrlConfigKey];

                var token_url_with_params = string.Format(
                        "{0}{1}",
                        ercot_token_url,
                        authTokenParameters.UrlParameters);

                var tokenResponse = await _httpClient.PostAsync(token_url_with_params, null, cancellationToken);
                
                ercotApiToken = await tokenResponse.Content.ReadFromJsonAsync<ErcotApiTokenResponse>(cancellationToken: cancellationToken);

                var expiryMinute = int.Parse(ercotApiToken?.expires_in) / 60 - 5;
                var expireTime = TimeSpan.FromMinutes(expiryMinute);

                _memoryCache.Set(_tokenCacheKey, ercotApiToken, expireTime);
            }

            return ercotApiToken ?? new ErcotApiTokenResponse();
        }
    }
}
