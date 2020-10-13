using BatlteCards.Data;
using Microsoft.EntityFrameworkCore;
using BattleCards.Controllers;
using SUS.HTTP;
using SUS.MVCFramework;
using System.Collections.Generic;

namespace BattleCards
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
        }

        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }
    }
}
