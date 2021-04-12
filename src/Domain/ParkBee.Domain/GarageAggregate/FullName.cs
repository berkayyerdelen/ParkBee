﻿using ParkBee.Domain.Core.Base;
using System.Collections.Generic;


namespace ParkBee.Domain.GarageAggregate
{
    public class FullName : ValueObject
    {
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public FullName(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
        public static FullName CreateFullName(string firstName, string middleName, string lastName) => new FullName(firstName, middleName, lastName);

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return MiddleName;
            yield return LastName;
        }
    }
}
