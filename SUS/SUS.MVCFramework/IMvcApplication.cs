using SUS.HTTP;
using System.Collections.Generic;

namespace SUS.MVCFramework
{
    public interface IMvcApplication
    {
        void ConfigureServices();

        void Configure(List<Route> routeTable);
    }
}
