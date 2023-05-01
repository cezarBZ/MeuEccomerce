using System;
using System.Text.Json.Serialization;


namespace MeuEccomerce.Domain.AggregatesModel.UserAggregate
{
    public class UserAddress
    {
        public UserAddress(Guid userId, string streetName, string city, string postalCode, string country)
        {
            UserId = userId;
            StreetName = streetName;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

    }
}
