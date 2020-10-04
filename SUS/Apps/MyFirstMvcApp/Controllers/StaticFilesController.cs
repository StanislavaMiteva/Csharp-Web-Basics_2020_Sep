using SUS.HTTP;
using SUS.MVCFramework;
using System.IO;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController: Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            byte[] fileBytes = File.ReadAllBytes("wwwroot/favicon_monitor.ico");
            HttpResponse response = new HttpResponse("image/vnd.microsoft.icon", fileBytes);

            return response;
        }
    }
}
