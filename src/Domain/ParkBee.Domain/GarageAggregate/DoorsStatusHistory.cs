using ParkBee.Domain.Core.Base;
using System;

namespace ParkBee.Domain.GarageAggregate
{
    public class DoorsStatusHistory : Entity
    {
        public Guid DoorId { get; private set; }
        public bool OldStatus { get; private set; }
        public bool NewStatus { get; private set; }
        public DateTime CreatedDate { get; private set; }
        protected DoorsStatusHistory(Guid doorId, bool oldStatus, bool newStatus, DateTime createdDate)
        {
            DoorId = doorId;
            OldStatus = oldStatus;
            NewStatus = newStatus;
            CreatedDate = createdDate;
        }
        public static DoorsStatusHistory CreateDoorsStatusHistory(Guid doorId, bool oldStatus, bool newStatus, DateTime createdDate)
            => new(doorId, oldStatus, newStatus, createdDate);
    }
}
