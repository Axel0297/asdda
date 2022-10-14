using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using System.Collections.Generic;
using System.Linq;

namespace NetChallenge
{
    public class OfficeRentalService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly IBookingRepository _bookingRepository;

        public OfficeRentalService(ILocationRepository locationRepository, IOfficeRepository officeRepository, IBookingRepository bookingRepository)
        {
            _locationRepository = locationRepository;
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;
        }

        public void AddLocation(AddLocationRequest request)
        {
            Location location = new Location
            {
                Name = request.Name,
                Neighborhood = request.Neighborhood
            };

            _locationRepository.Add(location);
        }

        public void AddOffice(AddOfficeRequest request)
        {
            Office office = new Office
            {
                Name = request.Name,
                LocationName = request.LocationName,
                MaxCapacity = request.MaxCapacity,
                AvailableResources = request.AvailableResources
            };

            _officeRepository.Add(office);
        }

        public void BookOffice(BookOfficeRequest request)
        {
            Booking booking = new Booking
            {
                LocationName = request.LocationName,
                OfficeName = request.OfficeName,
                DateTime = request.DateTime,
                Duration = request.Duration,
                UserName = request.UserName
            };

            _bookingRepository.Add(booking);
        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName)
        {
            List<BookingDto> bookingList = new List<BookingDto>();
            bookingList = (List<BookingDto>)_bookingRepository.AsEnumerable();

            IEnumerable<BookingDto> bookings = from booking in bookingList
                                               where booking.LocationName == locationName
                                               && booking.OfficeName == officeName
                                               select booking;
            return bookings;

        }


        public IEnumerable<LocationDto> GetLocations()
        {
            List<LocationDto> locations = new List<LocationDto>();
            locations = (List<LocationDto>)_locationRepository.AsEnumerable();
            return locations;
        }

        public IEnumerable<OfficeDto> GetOffices(string locationName)
        {
            List<OfficeDto> officesList = new List<OfficeDto>();
            officesList = (List<OfficeDto>)_officeRepository.AsEnumerable();

            IEnumerable<OfficeDto> offices = from office in officesList
                                               where office.LocationName == locationName
                                               select office;
            return offices;

        }

        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request)
        {
            List<OfficeDto> officesList = new List<OfficeDto>();
            officesList = (List<OfficeDto>)_officeRepository.AsEnumerable();

            List<LocationDto> locationList = new List<LocationDto>();
            locationList = (List<LocationDto>)_locationRepository.AsEnumerable();

            IEnumerable<OfficeDto> offices = from office in officesList
                                             where office.MaxCapacity == request.CapacityNeeded &&
                                             office.AvailableResources == request.ResourcesNeeded
                                             select office;

            IEnumerable<OfficeDto> officesOnRange = from office in offices join
                                                    location in locationList on request.PreferedNeigborHood
                                                    equals location.Neighborhood
                                                    select office;
            if(officesOnRange == null)
            {
                return offices;
            }

            return officesOnRange;

        }
    }
}