using Suls.Data;
using System.Linq;
using System;

namespace Suls.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;
        private readonly Random randomNumber;

        public SubmissionsService(ApplicationDbContext db, Random randomNumber)
        {
            this.db = db;
            this.randomNumber = randomNumber;
        }

        public void CreateSubmission(string code, string problemId, 
            string userId)
        {
            ushort problemMaxPoints= this.db.Problems
                .Where(x => x.Id ==problemId)
                .Select(x => x.Points)
                .FirstOrDefault();            
            
            var submission = new Submission
            {
                Code = code,
                AchievedResult= (ushort)this.randomNumber.Next(0, problemMaxPoints+1),
                CreatedOn = DateTime.UtcNow,
                ProblemId=problemId,
                UserId=userId
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
            //return submission.Id;
        }

        public void DeleteSubmission(string id)
        {
            var submission=this.db.Submissions
                .Find(id);                
            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
