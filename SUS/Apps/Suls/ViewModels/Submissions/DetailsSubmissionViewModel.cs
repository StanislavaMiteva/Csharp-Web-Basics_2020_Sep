using System;

namespace Suls.ViewModels.Submissions
{
    public class DetailsSubmissionViewModel
    {
        public string Username { get; set; }       

        public ushort AchievedResult { get; set; }

        public ushort MaxPoints { get; set; }

        public int Percentage => (int)Math.Round(this.AchievedResult * 100M / this.MaxPoints);

        public string CreatedOn { get; set; }

        public string SubmissionId { get; set; }
    }
}
