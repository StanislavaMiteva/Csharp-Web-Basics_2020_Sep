using SharedTrip.Data;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public string AddTrip(AddTripInputModel input)
        {
            var trip = new Trip
            {
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                DepartureTime = DateTime.ParseExact(input.DepartureTime,
                "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Description = input.Description,                
                ImagePath = input.ImagePath,
                Seats = input.Seats
            };

            this.db.Add(trip);
            this.db.SaveChanges();
            return trip.Id;
        }

        public IEnumerable<TripViewModel> GetAllTrips()
        {
            return this.db.Trips
                .Select(x => new TripViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime,
                    AvailableSeats = x.Seats - x.UserTrips.Count(),
                })
                .ToList();
        }

        public DetailsViewModel GetDetailsByTripId(string tripId)
        {
            return this.db.Trips
                .Where(x => x.Id == tripId)
                .Select(x => new DetailsViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime,
                    Description = x.Description,
                    ImagePath = x.ImagePath,                    
                    AvailableSeats = x.Seats - x.UserTrips.Count(),
                })
                .FirstOrDefault();
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            this.db.UserTrips.Add(new UserTrip
            {
                UserId = userId,
                TripId = tripId,
            });                         

            this.db.SaveChanges();
        }

        public bool UserCanJoinTrip(string tripId, string userId)
        {
            var userIsInTrip = this.db.UserTrips
                .Any(x => x.UserId == userId && x.TripId == tripId);
                
            var trip = this.db.Trips
                .Where(x => x.Id == tripId)
                .Select(x=> new { x.Seats, occupiedSeats=x.UserTrips.Count})
                .FirstOrDefault();
                      

            var freeSeats=trip.Seats-trip.occupiedSeats;

            return (!userIsInTrip && freeSeats > 0);            
        }
    }
}
