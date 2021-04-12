using ParkBee.Domain.Core.Base;


namespace ParkBee.Domain.GarageAggregate
{
    public class Door : Entity
    {
        public DoorType DoorType { get; private set; }
        public string Description { get; private set; }
        public string IPAddress { get; private set; }
        public bool IsActive { get; private set; }
        public Door(DoorType doorType, string description, string IPAddress, bool ısActive)
        {
            DoorType = doorType;
            Description = description;
            this.IPAddress = IPAddress;
            IsActive = ısActive;
        }

        public static Door CreateDoor(DoorType doorType, string description, string IPAddress, bool isActive)
            => new(doorType, description, IPAddress, isActive);

    }
}
