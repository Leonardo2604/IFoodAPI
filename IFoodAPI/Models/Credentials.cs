namespace IFoodAPI.Models
{
    public class Credentials
    {
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string GrantType { get; private set; }

        public Credentials(string clientId, string clientSecret, string username, string password)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Username = username;
            Password = password;
            GrantType = "password";
        }
    }
}
