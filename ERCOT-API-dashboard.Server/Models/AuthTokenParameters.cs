using ERCOT_API_dashboard.Server.Models.Interface;
using System.Net;

namespace ERCOT_API_dashboard.Server.Models
{
    public struct AuthTokenParameters : IUrlParameters
    {
        private readonly IConfiguration _config;
        private readonly string _token_username = "token:username";
        private readonly string _token_password = "token:password";
        private readonly string _token_api_subscription_key = "token:api_subscription_key";
        private readonly string _token_scope = "token:scope";
        private readonly string _token_client_id = "token:client_id";
        private readonly string _grant_type = "password";
        private readonly string _response_type = "id_token";

        public AuthTokenParameters(IConfiguration config) 
        {
            _config = config;
        }

        public string UserName
        { 
            get
            {
                return WebUtility.UrlEncode(_config[_token_username]) ?? string.Empty;
            }
        }

        public string Password 
        { 
            get
            {
                return WebUtility.UrlEncode(_config[_token_password]) ?? string.Empty;
            }
        }
        
        public string ApiSubscriptionKey
        {
            get
            {
                return _config[_token_api_subscription_key] ?? string.Empty;
            }
        }

        public string GrantType
        {
            get
            {
                return _grant_type;
            }
        }

        // token scope must not be URL Encoded !
        public string Scope
        {
            get
            {
                return _config[_token_scope] ?? string.Empty;
            }
        }
        
        public string ClientId
        {
            get
            {
                return _config[_token_client_id] ?? string.Empty;
            }
        }

        public string ResponseType
        {
            get
            {
                return _response_type;
            }
        }
        
        public string UrlParameters
        {
            get
            {
                return $"username={UserName}&password={Password}&grant_type={GrantType}&scope={Scope}&client_id={ClientId}&response_type={ResponseType}";
            }
        }
    }
}
