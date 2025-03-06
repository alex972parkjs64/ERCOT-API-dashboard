namespace ERCOT_API_dashboard.Server.Models
{
    public class AuthTokenParameters
    {        
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public string GrantType
        {
            get
            {
                return "password";
            }
        }
        public required string Scope { get; set; }
        public required string ClientId { get; set; }
        public string ResponseType
        {
            get
            {
                return "id_token";
            }
        }

        public string GenerateTokenUrlParameters()
        {
            return $"username={UserName}&password={Password}&grant_type={GrantType}&scope={Scope}&client_id={ClientId}&response_type={ResponseType}";
        }
    }
}
