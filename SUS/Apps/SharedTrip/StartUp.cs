namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Data;
    using SharedTrip.Services;
    using SUS.HTTP;
    using SUS.MVCFramework;
    using System.Collections.Generic;

    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ITripsService, TripsService>();
        }
    }
}
