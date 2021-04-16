using ParkBee.Domain.Core.Base;

namespace ParkBee.Domain.GarageAggregate
{
    public class Door : Entity
    {
        public DoorType DoorType { get; private set; }
        public string Description { get; private set; }
        public string IPAddress { get; private set; }
        public bool IsActive { get; private set; }
        private Door()
        {

        }
        public Door UpdateStatus(bool status)
        {
            IsActive = status;
            return this;
        }
        public Door ChangeDescription(string description)
        {
            Description = description;
            return this;
        }
        protected Door(DoorType doorType, string description, string IPAddress, bool isActive)
        {
            DoorType = doorType;
            Description = description;
            this.IPAddress = IPAddress;
            IsActive = isActive;
        }
        public static Door CreateDoor(DoorType doorType, string description, string IPAddress, bool isActive)
            => new(doorType, description, IPAddress, isActive);

    }
}
