using SUS.HTTP;
using SUS.MVCFramework;
using System;

namespace BattleCards.Controllers
{
    public class UsersController: Controller
    {
        public HttpResponse Login()
        {
            return this.View();            
        }

        public HttpResponse Register()
        {            
            return this.View();            
        }

        [HttpPost]
        public HttpResponse DoLogin()
        {
            //TODO: read data
            //TODO: check user
            //TODO: log user
            //TODO: redirect to home page
            return this.Redirect("/");
        }
    }
}
