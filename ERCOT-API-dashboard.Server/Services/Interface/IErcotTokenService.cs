using ERCOT_API_dashboard.Server.Models;

namespace ERCOT_API_dashboard.Server.Services.Interface
{
    public interface IErcotTokenService
    {
        Task<ErcotApiTokenResponse> GetErcotApiTokenAsync(AuthTokenParameters authTokenParameters, CancellationToken cancellationToken = default);
    }
}
