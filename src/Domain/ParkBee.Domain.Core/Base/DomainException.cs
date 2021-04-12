using System;

namespace ParkBee.Domain.Core.Base
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
