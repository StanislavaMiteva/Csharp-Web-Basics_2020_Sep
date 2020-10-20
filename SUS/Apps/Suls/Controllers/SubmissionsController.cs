using Suls.Services;
using Suls.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MVCFramework;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;
        private readonly IProblemsService problemsService;

        public SubmissionsController(ISubmissionsService submissionsService,
            IProblemsService problemsService)
        {
            this.submissionsService = submissionsService;
            this.problemsService = problemsService;
        }

        // get /Submissions/Create
        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                //TODO:
                return this.Redirect("/Users/Login");
            }

            var problemName = this.problemsService.GetProblemNameById(id);
            var createSubmissionViewModel = new CreateSubmissionViewModel
            {
                Name = problemName,
                ProblemId = id
            };

            return this.View(createSubmissionViewModel);
        }

        //post /Submissions/Create
        [HttpPost]
        public HttpResponse Create(string code, string problemId)
        {
            if (!this.IsUserSignedIn())
            {
                //TODO:
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            if (string.IsNullOrWhiteSpace(code) || code.Length<30 || code.Length>800)
            {
                return this.Error("Code should be between 30 and 800 characters");
            }

            this.submissionsService.CreateSubmission(code, problemId, userId);
            return this.Redirect("/");
        }

        //get /Submissions/Delete
        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                //TODO:
                return this.Redirect("/Users/Login");
            }

            this.submissionsService.DeleteSubmission(id);
            return this.Redirect("/");
        }
    }
}
