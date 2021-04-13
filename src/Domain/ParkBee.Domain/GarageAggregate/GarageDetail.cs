using ParkBee.Domain.Core.Base;
using System;
using System.Collections.Generic;


namespace ParkBee.Domain.GarageAggregate
{
    public class GarageDetail : Entity
    {
        public string GarageName { get; private set; }
        public GeoLocation GeoLocation { get; private set; }
        public Address Address { get; private set; }
        public Guid GarageId { get; set; }
        public List<Door> Doors { get; private set; }
        private GarageDetail()
        {

        }
        protected GarageDetail(string garageName, GeoLocation geoLocation, Address address, List<Door> doors)
        {
            GarageName = garageName;
            GeoLocation = geoLocation;
            Address = address;
            Doors = doors;
        }
        public GarageDetail CreateGarageDetail(string garageName, GeoLocation geoLocation, Address address, List<Door> doors)
               => new(garageName, geoLocation, address, doors);
    }
}
