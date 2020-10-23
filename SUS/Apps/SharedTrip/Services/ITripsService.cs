using SharedTrip.ViewModels.Trips;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        string AddTrip(AddTripInputModel input);

        IEnumerable<TripViewModel> GetAllTrips();

        DetailsViewModel GetDetailsByTripId(string tripId);

        bool UserCanJoinTrip(string tripId, string userId);

        void AddUserToTrip(string tripId, string userId);
    }
}
