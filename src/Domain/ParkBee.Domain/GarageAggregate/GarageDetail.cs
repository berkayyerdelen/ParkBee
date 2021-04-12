using ParkBee.Domain.Core.Base;
using System.Collections.Generic;


namespace ParkBee.Domain.GarageAggregate
{
    public class GarageDetail : Entity
    {
        public string GarageName { get; private set; }
        public GeoLocation GetGeoLocation { get; private set; }
        public Address Address { get; private set; }
        public List<Door> Doors { get; private set; }
    }
}
