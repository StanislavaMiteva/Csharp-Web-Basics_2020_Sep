using SUS.HTTP;
using SUS.MVCFramework;
using System;

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

        internal HttpResponse DoLogin(HttpRequest request)
        {
            //TODO: read data
            //TODO: check user
            //TODO: log user
            //TODO: redirect to home page
            return this.Redirect("/");
        }
    }
}
