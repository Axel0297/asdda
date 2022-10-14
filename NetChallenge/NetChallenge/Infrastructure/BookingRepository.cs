using NetChallenge.Abstractions;
using NetChallenge.Domain;
using System.Collections.Generic;
using System.Linq;

namespace NetChallenge.Infrastructure
{
    public class BookingRepository : IBookingRepository
    {
        readonly List<Booking> Bookings = new List<Booking>();

        public IEnumerable<Booking> AsEnumerable()
        {
            IEnumerable<Booking> lst =
               from b in Bookings
               select b;
            return lst;
        }

        public void Add(Booking item)
        {
            Bookings.Add(item);
        }
    }
}