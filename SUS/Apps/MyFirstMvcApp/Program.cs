using MyFirstMvcApp.Controllers;
using SUS.HTTP;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            server.AddRoute("/", new HomeController().Index);
            server.AddRoute("/niki", (request) =>
            {
                return new HttpResponse("text/html", new byte[] { 0x56, 0x57 });
            });
            server.AddRoute("/favicon.ico", new StaticFilesController().Favicon);
            server.AddRoute("/about", new HomeController().About);
            server.AddRoute("/users/login", new UsersController().Login);
            server.AddRoute("/users/register", new UsersController().Register);
            //Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "http://localhost");
            await server.StartAsync(80);
        }
    }
}
