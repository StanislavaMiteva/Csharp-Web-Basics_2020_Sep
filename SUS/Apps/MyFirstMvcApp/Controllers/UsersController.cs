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

        [HttpPost("/Users/Login")]
        public HttpResponse DoLogin()
        {
            //TODO: read data
            //TODO: check user
            //TODO: log user
            //TODO: redirect to home page
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {            
            return this.View();            
        }

        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister()
        {
            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Only logged-in users can logout");                
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
