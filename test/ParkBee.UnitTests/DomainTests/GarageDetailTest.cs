using ParkBee.Domain.Core.Base;
using ParkBee.Domain.GarageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkBee.UnitTests.DomainTests
{
    public class GarageDetailTest
    {
        private GarageDetail garageDetail;
        public GarageDetailTest()
        {
            garageDetail = GarageDetail.CreateGarageDetail("Parkbee", GeoLocation.CreateGeoLocation(5, 30),
                Address.CreateAddress("Netherland", "Amsterdam", "Previous st.", "10080"),
                 new List<Door>()
                             {
                                Door.CreateDoor(DoorType.Entry,"Entry Door 1","d99948a4-71b8-4c67-b1c5-516bd386e152",true),
                                Door.CreateDoor(DoorType.Exit,"Entry Exit","02ca2795-9f3c-4e07-ae10-cc60b62660f0",true),
                                Door.CreateDoor(DoorType.Entry,"Entry Door 2","44971013-6e13-41ac-840d-177e05df8899",false)
                              });
        }
        [Fact]
        public void Should_Have_Create_GarageDetail()
        {
            Assert.NotNull(garageDetail);
        }
        [Fact]
        public void Should_Have_Create_Door()
        {
            garageDetail.AddDoor(Door.CreateDoor(DoorType.Entry, "Entry Door 3", "720eb833-2f8c-4906-978e-22822ac0a4b0", true));
            Assert.Equal(4, garageDetail.Doors.Count());
        }
        [Fact]
        public void Should_Have_Remove_Door()
        {
            garageDetail.RemoveDoor("d99948a4-71b8-4c67-b1c5-516bd386e152");
            var door = garageDetail.Doors.FirstOrDefault(x => x.IPAddress == "d99948a4-71b8-4c67-b1c5-516bd386e152");
            Assert.Null(door);
        }
        [Fact]
        public void Should_Have_Update_Door()
        {
            garageDetail.UpdateDoorStatus(false, "d99948a4-71b8-4c67-b1c5-516bd386e152");
            var door = garageDetail.Doors.FirstOrDefault(x => x.IPAddress == "d99948a4-71b8-4c67-b1c5-516bd386e152");
            Assert.False(door.IsActive);
        }
        [Fact]
        public void Should_Have_Thrown_Domain_Exception_While_Update_Door_Status()
        {
            var exceptionMessage = "Door is offline or not reachable atm";
            var exception = Assert.Throws<DomainException>(() => { garageDetail.UpdateDoorStatus(false, ""); });
            Assert.Equal(exceptionMessage, exception.Message);
        }
        [Fact]
        public void Shold_Have_Set_Garage_Name()
        {
            var garageName = "Bumblebee";
            garageDetail.SetGarageName(garageName);
            Assert.Equal(garageName, garageDetail.GarageName);

        }
        [Fact]
        public void Shold_Have_Set_Address()
        {
            var address = Address.CreateAddress("Netherland", "Amsterdam", "Previous 2", "1000");
            garageDetail.SetAddress(address);
            Assert.Equal(address, garageDetail.Address);
        }
        [Fact]
        public void Shold_Have_Set_GeoLocation()
        {
            var geoLocation = GeoLocation.CreateGeoLocation(0, 0);
            garageDetail.SetGeoLocation(geoLocation);
            Assert.Equal(geoLocation, garageDetail.GeoLocation);
        }
    }
}
