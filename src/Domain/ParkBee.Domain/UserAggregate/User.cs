using ParkBee.Domain.Core.Base;
using ParkBee.Domain.GarageAggregate;

namespace ParkBee.Domain.UserAggregate
{
    public class User : Entity
    {
        public FullName FullName { get; private set; }
        public UserCredentials UserCredentials { get;private set; }
        private User()
        {

        }
        protected User(FullName fullName, UserCredentials userCredentials)
        {
            FullName = fullName;
            UserCredentials = userCredentials;
        }
        public User UpdateFullName(FullName fullName)
        {
            if (FullName is null)
                throw new DomainException("Fullname can not be null");
            FullName = fullName;
            return this;
        }   
        public static User CreateCustomer(FullName fullName,UserCredentials userCredentials) => new(fullName, userCredentials);
      
    }
}
