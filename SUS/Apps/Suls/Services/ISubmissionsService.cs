namespace Suls.Services
{
    public interface ISubmissionsService
    {    
        void CreateSubmission(string code, string problemId, 
            string userId);

        void DeleteSubmission(string id);
    }
}
