using ParkBee.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkBee.Domain.GarageAggregate
{
    public class GarageDetail : Entity
    {
        public string GarageName { get; private set; }
        public GeoLocation GeoLocation { get; private set; }
        public Address Address { get; private set; }
        public Guid GarageId { get; set; }
        public List<Door> Doors { get; private set; }
        public GarageDetail UpdateDoorStatus(bool status, string IPAddress)
        {
            var door = Doors.FirstOrDefault(x => x.IPAddress == IPAddress);
            if (door is null)
                throw new DomainException("Door is offline or not reachable atm");
            door.UpdateStatus(status);
            return this;
        }
        public GarageDetail RemoveDoor(string IPAddress)
        {
            var door = Doors.FirstOrDefault(x => x.IPAddress == IPAddress);
            Doors.Remove(door);
            return this;
        }
        public GarageDetail UpdateDoorDetail(Door door)
        {
            var existingDoor = Doors.FirstOrDefault(x => x.IPAddress == door.IPAddress);
            existingDoor = door;
            return this;
        }
        public GarageDetail AddDoor(Door door)
        {
            Doors.Add(door);
            return this;
        }
        public void SetGeoLocation(GeoLocation geoLocation)
        {
            GeoLocation = geoLocation;
        }
        public void SetAddress(Address address)
        {
            Address = address;
        }
        public GarageDetail SetGarageName(string garageName)
        {
            GarageName = garageName;
            return this;
        }
        private GarageDetail() { }
        protected GarageDetail(string garageName, GeoLocation geoLocation, Address address, List<Door> doors)
        {
            GarageName = garageName;
            GeoLocation = geoLocation;
            Address = address;
            Doors = doors;
        }
        public static GarageDetail CreateGarageDetail(string garageName, GeoLocation geoLocation, Address address, List<Door> doors)
               => new(garageName, geoLocation, address, doors);
    }
}
