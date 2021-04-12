using ParkBee.Domain.Core.Base;


namespace ParkBee.Domain.GarageAggregate
{
    public class Customer : Entity
    {
        public FullName FullName { get; private set; }

        public Customer(FullName fullName)
        {
            FullName = fullName;
        }
        public static Customer CreateCustomer(FullName fullName) => new(fullName);
    }
}
