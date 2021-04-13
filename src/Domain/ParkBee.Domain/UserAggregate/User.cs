using ParkBee.Domain.Core.Base;
using ParkBee.Domain.GarageAggregate;
using System;

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
        protected User(Guid id,FullName fullName, UserCredentials userCredentials)
        {
            FullName = fullName;
            UserCredentials = userCredentials;
            Id = id;
        }
        public User UpdateFullName(FullName fullName)
        {
            if (FullName is null)
                throw new DomainException("Fullname can not be null");
            FullName = fullName;
            return this;
        }   
        public static User CreateCustomer(FullName fullName,UserCredentials userCredentials) => new(fullName, userCredentials);
        public static User CreateCustomerWithId(Guid id,FullName fullName, UserCredentials userCredentials) => new(id,fullName, userCredentials);

    }
}
