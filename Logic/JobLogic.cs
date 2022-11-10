using Logic;
using ClassHolder;
using MainDataBase;
public class JobLogic
{

    JobDB newJobDB = new();
    CompanyLogic newCompLogic = new();

    public void CreateNewJob(string title, string description, string location)
    {
        Job newJob = new(newCompLogic.loggedInCompanyId, title, description, location);
        newJobDB.AddJobToDB(newJob);
        // newJobDB.AddJobLicenseAndEducation(newJobDB.FindJobID(loggedInUserId), SeekerLicenseChoice(), SeekerEducationChoice());
    }
}