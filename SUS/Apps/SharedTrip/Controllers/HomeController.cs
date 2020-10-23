namespace SharedTrip.Controllers
{
    using SUS.HTTP;
    //using SUS.MvcFramework;
    using SUS.MVCFramework;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }
    }
}
