using Suls.ViewModels.Problems;
using System.Collections.Generic;

namespace Suls.Services
{
    public interface IProblemsService
    {
        string Create(string name, ushort points);

        IEnumerable<HomePageProblemViewModel> GetAllProblems();

        string GetProblemNameById(string id);

        ProblemDetailsViewModel GetProblemDetailsById(string problemId);
    }
}
