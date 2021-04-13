using ParkBee.Domain.Core.Base;
using System.Collections.Generic;

namespace ParkBee.Domain.GarageAggregate
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
        public static User CreateCustomer(FullName fullName,UserCredentials userCredentials) => new(fullName, userCredentials);
    }
    public class UserCredentials : ValueObject
    {
        public string UserName { get; }
        public string Password { get; }

        public UserCredentials(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }      
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return UserName;
            yield return Password;
        }
    }
}
