using ParkBee.Domain.Core.Base;
using System;

namespace ParkBee.Domain.GarageAggregate
{
    public class Garage : Entity, IAggregateRoot
    {
        public string GarageName { get; private set; }
        public string CountryCode { get; private set; }
        public GarageDetail GarageDetail { get; private set; }
        public Garage SetGarageName (string garageName)
        {
            if (string.IsNullOrEmpty(garageName))
                throw new DomainException("Garage Name can not be null or empty");
            GarageName = garageName;
            return this;
        }
        public Garage SetCountryCode(string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode))
                throw new DomainException("Country code can not be null or empty");
            CountryCode = countryCode; 
            return this;
        }
        public Guid CustomerId { get; private set; }
        private Garage(){ }

        protected Garage(string garageName, string countryCode, GarageDetail garageDetail, Guid customerId)
        {
            GarageName = garageName;
            CountryCode = countryCode;
            GarageDetail = garageDetail;
            CustomerId = customerId;
        }
        public static Garage CreateGarage(string garageName, string countryCode, GarageDetail garageDetail, Guid customerId)
            => new(garageName, countryCode, garageDetail, customerId);
    }
}
