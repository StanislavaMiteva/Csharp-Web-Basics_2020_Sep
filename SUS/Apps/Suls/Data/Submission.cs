using System;
using System.ComponentModel.DataAnnotations;

namespace Suls.Data
{
    public class Submission
    {
        public Submission()
        {
            this.Id = Guid.NewGuid().ToString();
        }
                
        public string Id { get; set; }

        [Required]
        [MaxLength(800)]
        public string Code { get; set; }

        public ushort AchievedResult  { get; set; }

        public DateTime CreatedOn  { get; set; }

        //[ForeignKey(nameof(Problem))]
        public string ProblemId { get; set; }
        public virtual Problem Problem { get; set; }

        //[ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
