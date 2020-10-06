using SUS.HTTP;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SUS.MVCFramework
{
    public static class Host
    {
        public static async Task CreateHostAsync(List<Route> routeTable, int port=80)
        {
            //TODO: {controller}/{action}/{id}
            IHttpServer server = new HttpServer(routeTable);            

            //Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "http://localhost");
            await server.StartAsync(port);
        }
    }
}
