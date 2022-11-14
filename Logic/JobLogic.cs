using Logic;
using ClassHolder;
using MainDataBase;
public class JobLogic
{
    JobDB newJobDB = new();
    SeekerLogic neS = new();


    public void CreateNewJob(string title, string description, string location, int license, int education)
    {
        Job newJob = new(CompanyLogic.loggedInCompanyId, title, description, location);
        newJobDB.AddJobToDB(newJob);
        newJobDB.AddJobLicenseAndEducation(newJobDB.FindJobID(CompanyLogic.loggedInCompanyId), license, education);
    }
}