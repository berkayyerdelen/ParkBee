using ParkBee.Domain.Core.Base;
using System.Collections.Generic;
namespace ParkBee.Domain.UserAggregate
{
    public class UserCredentials : ValueObject
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public UserCredentials(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public UserCredentials UpdatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new DomainException("Password can not be null or empty");
            Password = password;
            return this;
        }
        public static UserCredentials CreateUserCredentials(string username, string password) => new UserCredentials(username, password);
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return UserName;
            yield return Password;
        }
    }
}
