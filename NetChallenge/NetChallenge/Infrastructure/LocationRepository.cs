using NetChallenge.Abstractions;
using NetChallenge.Domain;
using System.Collections.Generic;
using System.Linq;

namespace NetChallenge.Infrastructure
{
    public class LocationRepository : ILocationRepository
    {
        readonly List<Location> Locations = new List<Location>();

        public IEnumerable<Location> AsEnumerable()
        {
            IEnumerable<Location> lst =
               from l in Locations
               select l;
               return lst;
        }

        public void Add(Location item)
        {
            Locations.Add(item);
        }
    }
}