using NetChallenge.Abstractions;
using NetChallenge.Domain;
using System.Collections.Generic;
using System.Linq;

namespace NetChallenge.Infrastructure
{
    public class OfficeRepository : IOfficeRepository
    {
        readonly List<Office> Offices = new List<Office>();

        public IEnumerable<Office> AsEnumerable()
        {
            IEnumerable<Office> lst =
               from o in Offices
               select o;
               return lst;
        }

        public void Add(Office item)
        {
            Offices.Add(item);
        }
    }
}   