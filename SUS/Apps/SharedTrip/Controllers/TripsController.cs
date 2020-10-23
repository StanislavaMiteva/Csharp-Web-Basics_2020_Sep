using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SUS.HTTP;
using SUS.MVCFramework;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SharedTrip.Controllers
{
    public class TripsController :Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }
        // get /Trips/All 
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            IEnumerable<TripViewModel> model = this.tripsService.GetAllTrips();
            return this.View(model);
        }

        // get /Trips/Add
        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            return this.View();
        }

        //POST /Trips/Add
        [HttpPost]
        public HttpResponse Add(AddTripInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(input.StartPoint))
            {
                return this.Error("Starting Point is required.");
            }

            if (string.IsNullOrEmpty(input.EndPoint))
            {
                return this.Error("End Point is required.");
            }

            if (string.IsNullOrWhiteSpace(input.DepartureTime) ||
                !DateTime.TryParseExact(input.DepartureTime, "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                return this.Error("Departure Time is required in format: dd.MM.yyyy HH:mm");
            }

            if (input.Seats<2 || input.Seats>6)
            {
                return this.Error("Seats should be an integer between 2 and 6.");
            }

            if (string.IsNullOrEmpty(input.Description) || input.Description.Length>80)
            {
                return this.Error("Description is required and should be maximum 80 characters long.");
            }

            this.tripsService.AddTrip(input);

            return this.Redirect("/Trips/All");
        }

        //Get /Trips/Details
        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            DetailsViewModel model = this.tripsService.GetDetailsByTripId(tripId);
            return this.View(model);
        }

        //Get /Trips/AddUserToTrip
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            if (this.tripsService.UserCanJoinTrip(tripId, userId))
            {
                this.tripsService.AddUserToTrip(tripId, userId);
                return this.Redirect("/Trips/All");
            }
            else
            {
                return this.Redirect("/Trips/Details?tripId=" + tripId);
            }
        }
    }
}
