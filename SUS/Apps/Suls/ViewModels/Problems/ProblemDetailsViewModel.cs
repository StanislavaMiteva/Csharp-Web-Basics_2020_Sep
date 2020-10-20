using Suls.ViewModels.Submissions;
using System.Collections.Generic;

namespace Suls.ViewModels.Problems
{
    public class ProblemDetailsViewModel
    {
        //public ProblemDetailsViewModel()
        //{
        //    this.Submissions = new List<DetailsSubmissionViewModel>();
        //}
        public string Name { get; set; }

        public IEnumerable<DetailsSubmissionViewModel> Submissions { get; set; }
        
    }
}
