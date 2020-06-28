using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }

        [JsonProperty("token_type")]
        public string TokenType { get; private set; }

        [JsonProperty("expires_in")]
        public string ExpiresIn { get; private set; }
        
        [JsonProperty("scope")]
        public string Scope { get; private set; }

        public string FullToken
        {
            get
            {
                return $"{TokenType} {AccessToken}";
            }
        }

        public Token()
        {

        }

        [JsonConstructor]
        public Token(string tokenType, string accessToken, string expiresIn, string scope)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            ExpiresIn = expiresIn;
            Scope = scope;
        }
    }
}
