using SUS.HTTP;
using System.Collections.Generic;

namespace SUS.MVCFramework
{
    public interface IMvcApplication
    {
        void ConfigureServices(IServiceCollection serviceCollection);

        void Configure(List<Route> routeTable);
    }
}
