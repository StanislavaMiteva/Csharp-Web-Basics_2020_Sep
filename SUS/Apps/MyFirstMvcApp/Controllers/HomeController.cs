using SUS.HTTP;
using SUS.MVCFramework;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController: Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            return this.View();
        }
    }
}
