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
    public class GarageTest
    {
        private Garage garage;
        private Guid CustomerId;
        public GarageTest()
        {
            CustomerId = Guid.NewGuid();
            garage = Garage.CreateGarage("Parkbee", "nl", null, CustomerId);
        }
        [Fact]
        public void Should_Have_Create_Garage()
        {           
            Assert.NotNull(garage);
            Assert.Equal("Parkbee", garage.GarageName);
            Assert.Equal("nl", garage.CountryCode);
            Assert.Equal(CustomerId, garage.CustomerId);
        }
        [Fact]
        public void Should_Have_Update_Country_Code()
        {
            garage.SetCountryCode("ru");
            Assert.Equal("ru", garage.CountryCode);
        }
        [Fact]
        public void Should_Have_Throw_Domain_Exception()
        {
           
            Assert.Throws<DomainException>(()=> 
            {
                garage.SetCountryCode("");
            });
        }
        [Fact]
        public void Should_Have_Thrown_Domain_Exception_With_Spesific_Exceptions_Message()
        {
            var exceptionMessage = "Garage Name can not be null or empty";
            var exception = Assert.Throws<DomainException>(() =>
            {
                garage.SetGarageName("");
            });
            Assert.Equal(exceptionMessage, exception.Message);
        }
    }
}
