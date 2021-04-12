using ParkBee.Domain.Core.Base;
using System.Collections.Generic;


namespace ParkBee.Domain.GarageAggregate
{
    public class Address : ValueObject
    {
        public string Country { get; }
        public string City { get; }
        public string StreetAddress { get; }
        public string PostalCode { get; }

        public Address(string country, string city, string streetAddress, string postalCode)
        {
            Country = country;
            City = city;
            StreetAddress = streetAddress;
            PostalCode = postalCode;
        }
        public static Address CreateAddress(string country, string city, string streetAddress, string postalCode) 
            => new (country, city, streetAddress, postalCode);
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Country;
            yield return City;
            yield return StreetAddress;
            yield return PostalCode;

        }
    }
}
