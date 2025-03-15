using Microsoft.Extensions.Configuration;

using ERCOT_API_dashboard.Server.Models;
using System.Net;

namespace ERCOT_API_dashboard.UnitTests
{
    public class AuthTokenParameters_tests
    {
        private readonly IConfiguration _config;
        private readonly string _username = "test$User%Name";
        private readonly string _password = "super^secret*#stuff";
        private readonly string _api_subscription_key = "ap1subs0pt10nk3y";
        private readonly string _grant_type = "password";
        private readonly string _scope = "must+not345-34y33e53+url_encode";
        private readonly string _client_id = "cl13nt-1d-3423-t32t1ng";
        private readonly string _response_type = "id_token";

        private readonly string _url_encoded_username;
        private readonly string _url_encoded_password;

        private readonly AuthTokenParameters _auth_token_params;

        public AuthTokenParameters_tests()
        {
            var inMemorySettings = new Dictionary<string, string?>
            {
                { "token:username",  _username },
                { "token:password",  _password },
                { "token:api_subscription_key", _api_subscription_key },
                { "token:scope", _scope },
                { "token:client_id", _client_id }
            };

            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _url_encoded_username = WebUtility.UrlEncode(_username);
            _url_encoded_password = WebUtility.UrlEncode(_password);


            _auth_token_params = new AuthTokenParameters(_config);
        }

        [Fact]
        public void IsUsernameUrlEncoded()
        {
            Assert.Equal(_url_encoded_username, _auth_token_params.UserName);
        }

        [Fact]
        public void IsPasswordUrlEncoded()
        {
            Assert.Equal(_url_encoded_password, _auth_token_params.Password);
        }

        [Fact]
        public void IsApiSubscriptionKeyCorrect()
        {
            Assert.Equal(_api_subscription_key, _auth_token_params.ApiSubscriptionKey);
        }

        [Fact]
        public void IsGrantTypeCorrect()
        {
            Assert.Equal(_grant_type, _auth_token_params.GrantType);
        }

        [Fact]
        public void IsScopeCorrect()
        {
            Assert.Equal(_scope, _auth_token_params.Scope);
        }

        [Fact]
        public void IsClientIdCorrect()
        {
            Assert.Equal(_client_id, _auth_token_params.ClientId);
        }

        [Fact]
        public void IsResponseTypeCorrect()
        {
            Assert.Equal(_response_type, _auth_token_params.ResponseType);
        }

        [Fact]
        public void IsTokenUrlParameterCorrect()
        {
            var expectedTokenUrlWithParameters = 
                string.Format("username={0}&password={1}&grant_type={2}&scope={3}&client_id={4}&response_type={5}",
                    _url_encoded_username, _url_encoded_password, _grant_type, _scope, _client_id, _response_type);

            Assert.Equal(expectedTokenUrlWithParameters, _auth_token_params.TokenUrlParameters);
        }
    }
}
