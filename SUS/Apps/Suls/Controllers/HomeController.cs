using Suls.Services;
using SUS.HTTP;
using SUS.MVCFramework;

namespace Suls.Controllers
{
    public class HomeController :Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                //Home/IndexLoggedIn
                var homePageProblemsViewModel = this.problemsService.GetAllProblems();                
                return this.View(homePageProblemsViewModel, "IndexLoggedIn");
            }
            else
            {
                //Home/Index
                return this.View();
            }                
        }      
    }
}
