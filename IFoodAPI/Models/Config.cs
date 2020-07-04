namespace IFoodAPI.Models
{
    public class Config
    {
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string GrantType { get; private set; }
        public int MerchantId { get; private set; }

        public Config(string clientId, string clientSecret, string username, string password, int merchantId)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Username = username;
            Password = password;
            GrantType = "password";
            MerchantId = merchantId;
        }
    }
}
