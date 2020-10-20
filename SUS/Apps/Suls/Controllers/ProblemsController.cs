using Suls.Services;
using Suls.ViewModels.Problems;
using SUS.HTTP;
using SUS.MVCFramework;

namespace Suls.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                //TODO:
                //return this.Redirect("/");
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, ushort points)
        {
            if (!this.IsUserSignedIn())
            {
                //TODO:
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(name) || name.Length<5 || name.Length>20)
            {
                return this.Error("Name should be between 5 and 20 characters long.");
            }

            if (points < 50 || points >300)
            {
                return this.Error("Points should be an integer between 50 and 300");
            }

            this.problemsService.Create(name, points);
            return this.Redirect("/");
        }

        ///Problems/Details
        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignedIn())
            {
                //TODO:
                return this.Redirect("/Users/Login");
            }

            ProblemDetailsViewModel detailsViewModel = this.problemsService.GetProblemDetailsById(id);   
            return this.View(detailsViewModel);
        }        
    }
}
