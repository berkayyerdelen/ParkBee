using ParkBee.Domain.Core.Base;
using System;


namespace ParkBee.Domain.GarageAggregate
{
    public class Garage : Entity, IAggregateRoot
    {
        public string GarageName { get; private set; }
        public string CountryCode { get; private set; }
        public GarageDetail GarageDetail { get; private set; }
        public Customer Customer { get; private set; }
    }
}
