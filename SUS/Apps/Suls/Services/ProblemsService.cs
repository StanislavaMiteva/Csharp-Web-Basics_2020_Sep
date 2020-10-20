using Suls.Data;
using Suls.ViewModels.Problems;
using Suls.ViewModels.Submissions;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Suls.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext db;

        public ProblemsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Create(string name, ushort points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points,
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();

            return problem.Id;
        }

        public IEnumerable<HomePageProblemViewModel> GetAllProblems()
        {
            return this.db.Problems
                .Select(x => new HomePageProblemViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Submissions.Count,
                })
                .ToList();
        }

        public string GetProblemNameById(string id)
        {
            return this.db.Problems
                .Where(x => x.Id == id)
                .Select(x=> x.Name)
                .FirstOrDefault();
            //return this.db.Problems.FirstOrDefault(x => x.Id == id)?.Name;
        }

        public ProblemDetailsViewModel GetProblemDetailsById(string problemId)
        {
            var problemDetails = this.db.Problems
                .Where(x => x.Id == problemId)
                .Select(x => new ProblemDetailsViewModel
                {
                    Name = x.Name,
                    Submissions = x.Submissions
                        .Select(x => new DetailsSubmissionViewModel
                        {
                            AchievedResult = x.AchievedResult,
                            CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                            Username = x.User.Username,
                            SubmissionId = x.Id,
                            MaxPoints = x.Problem.Points
                        })
                        .ToList()
                })
                .FirstOrDefault();

            return problemDetails;
        }
    }
}
