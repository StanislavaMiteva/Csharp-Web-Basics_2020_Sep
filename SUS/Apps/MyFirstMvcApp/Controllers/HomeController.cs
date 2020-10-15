using BattleCards.ViewModels;
using SUS.HTTP;
using SUS.MVCFramework;
using System;

namespace BattleCards.Controllers
{
    public class HomeController: Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cards/All");
            }

            return this.View();
        }        
    }
}
