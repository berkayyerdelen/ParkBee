using System;

namespace ParkBee.Core.Common.Exceptions
{
    public class BusinessException:Exception
    {
        public BusinessException(string message):base(message)
        {

        }
    }
}
