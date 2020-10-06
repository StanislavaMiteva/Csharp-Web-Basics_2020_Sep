using SUS.HTTP;
using SUS.MVCFramework;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController: Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View();            
        }

        public HttpResponse Register(HttpRequest request)
        {
            return this.View();            
        }
    }
}
