using ParkBee.Domain.Core.Base;
using System.Collections.Generic;


namespace ParkBee.Domain.GarageAggregate
{
    public class GeoLocation : ValueObject
    {
        public int Latitude { get; }
        public int Longitude { get; }
        public GeoLocation(int latitude, int longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        public static GeoLocation CreateGeoLocation(int latitude, int longitude) => new (latitude, longitude);

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Latitude;
            yield return Longitude;
        }
    }
}
