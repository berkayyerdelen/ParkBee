using ParkBee.Domain.Core.Base;


namespace ParkBee.Domain.GarageAggregate
{
    public class Customer : Entity
    {
        public FullName FullName { get; private set; }
    }
}
