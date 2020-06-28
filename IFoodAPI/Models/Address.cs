using Newtonsoft.Json;

namespace IFoodAPI.Models
{
    public class Address
    {
        [JsonProperty("formattedAddress")]
        public string FormattedAddress { get; private set; }
        
        [JsonProperty("country")]
        public string Country { get; private set; }

        [JsonProperty("state")]
        public string State { get; private set; }
        
        [JsonProperty("city")]
        public string City { get; private set; }
        
        [JsonProperty("neighborhood")]
        public string Neighborhood { get; private set; }
        
        [JsonProperty("streetName")]
        public string StreetName { get; private set; }

        [JsonProperty("streetNumber")]
        public string StreetNumber { get; private set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; private set; }

        [JsonProperty("reference")]
        public string Reference { get; private set; }

        [JsonProperty("complement")]
        public string Complement { get; private set; }

        public Address(string formattedAddress, string country, string state, string city, string neighborhood, string streetName, string streetNumber, string postalCode, string reference, string complement)
        {
            FormattedAddress = formattedAddress;
            Country = country;
            State = state;
            City = city;
            Neighborhood = neighborhood;
            StreetName = streetName;
            StreetNumber = streetNumber;
            PostalCode = postalCode;
            Reference = reference;
            Complement = complement;
        }
    }
}
