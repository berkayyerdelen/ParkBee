using ParkBee.Domain.Core.Base;
using System;

namespace ParkBee.Domain.UserAggregate
{
    public class User : Entity
    {
        public FullName FullName { get; private set; }
        public UserCredentials UserCredentials { get; private set; }
        public Role Role { get; private set; }
        private User()
        {

        }
        protected User(FullName fullName, UserCredentials userCredentials, Role role)
        {
            FullName = fullName;
            UserCredentials = userCredentials;
            Role = role;
        }
        protected User(Guid id, FullName fullName, UserCredentials userCredentials,Role role)
        {
            FullName = fullName;
            UserCredentials = userCredentials;
            Id = id;
            Role = role;
        }
        public User UpdateUserRole(Role role)
        {
            Role = role;
            return this;
        }
        public User UpdateFullName(FullName fullName)
        {
            if (FullName is null)
                throw new DomainException("Fullname can not be null");
            FullName = fullName;
            return this;
        }
        public static User CreateCustomer(FullName fullName, UserCredentials userCredentials, Role role) => new(fullName, userCredentials, role);
        public static User CreateCustomerWithId(Guid id, FullName fullName, UserCredentials userCredentials, Role role) => new(id, fullName, userCredentials, role);

    }
}
