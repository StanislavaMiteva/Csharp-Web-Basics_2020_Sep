using BatlteCards.Data;
using Microsoft.EntityFrameworkCore;
using SUS.HTTP;
using SUS.MVCFramework;
using System.Collections.Generic;
using BattleCards.Services;

namespace BattleCards
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ICardsService, CardsService>();
        }

        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }
    }
}
