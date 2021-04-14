using ParkBee.Domain.GarageAggregate;
using Xunit;

namespace ParkBee.UnitTests.DomainTests
{
    public class DoorTest
    {
        private Door door;
        public DoorTest()
        {
            door = Door.CreateDoor(DoorType.Entry, "Entry 1", "05797f33-2d8e-4eeb-8aad-f99616041b49", false);
        }
        [Fact]
        public void Should_Have_Create_GarageDetail()
        {
            Assert.NotNull(door);
        }
        [Fact]
        public void Should_Have_Set_Door_Status()
        {
            door.UpdateStatus(true);
            Assert.True(door.IsActive);
        }
        [Fact]
        public void Should_Have_Update_Description()
        {
            door.ChangeDescription("This is sample test");
            Assert.Equal("This is sample test", door.Description);
        }
    }
}
