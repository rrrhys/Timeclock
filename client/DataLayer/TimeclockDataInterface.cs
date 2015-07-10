using System;
namespace DataLayer
{
    public interface TimeclockDataInterface
    {
        bool CheckTokenIsValid(Guid? token);
        Guid? CreateJobEntry(entry e, Guid user_token);
        job_numbers CreateJobNumbers(string p, Guid user_token);
        Guid? CreateUser(string email, string password);
        work_types CreateWorkType(string p, Guid user_token);
        Guid? GetTokenForUser(string email, string password);
        job_numbers[] ListJobNumbers(Guid user_token);
        work_types[] ListWorkTypes(Guid user_token);
        void UpdateEntry(Guid entryToken, string comments);
    }
}
