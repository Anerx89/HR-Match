using MainDataBase;
namespace Logic;

public class MainLogic
{
    MainDBFunc newDB = new();
    SeekerDB seekerDB = new();
    CompanyDB companyDB = new();
    JobDB jobDB = new();

    int loggedInUserId = 0;

    public bool CreateNewJobSeeker(string name, int age, string email, string password, string exp)
    {
        if (password.Length >= 2 && !password.Contains(" "))//Dont forget to change!!!
        {
            Seeker newJS = new(name, age, email, password, exp);
            seekerDB.AddJobSeekerToDB(newJS);
            seekerDB.AddSeekerLicenseAndEducation(seekerDB.FindSeekerID(name), SeekerLicenseChoice(), SeekerEducationChoice());
            return true;
        }
        return false;
    }

    public bool CreateNewCompany(string name, string location, string workArea, string email, string password)
    {
        if (password.Length >= 2 && !password.Contains(" "))
        {
            Company newComp = new(name, location, workArea, email, password);
            companyDB.AddCompanyToDB(newComp);
            return true;
        }
        return false;
    }

    public void CreateNewJob(string title, string description, string location)
    {
        Job newJob = new(loggedInUserId, title, description, location);
        jobDB.AddJobToDB(newJob);
        jobDB.AddJobLicenseAndEducation(jobDB.FindJobID(loggedInUserId), SeekerLicenseChoice(), SeekerEducationChoice());
    }


    public bool LoginJobSeeker(string email, string password)
    {
        foreach (var item in seekerDB.SearchSeekerInDB())
        {
            if (item.Seeker_email.Contains(email) && item.Password.Contains(password))
            {
                loggedInUserId = item.Seeker_id;
                seekerDB.GetSeekerLicense(loggedInUserId);
                newDB.GetJobLicense(loggedInUserId);
                return true;
            }
        }
        return false;
    }
    public bool LoginCompany(string email, string password)
    {
        foreach (var item in companyDB.SearchCompanyInDB())
        {
            if (item.C_email.Contains(email) && item.Password.Contains(password))
            {
                loggedInUserId = item.C_id;
                Console.WriteLine(loggedInUserId);
                Console.ReadLine();
                return true;
            }
        }
        return false;
    }

    public int SeekerLicenseChoice()
    {
        int stringNew = 2;
        return stringNew;
    }
    public int SeekerEducationChoice()
    {
        int stringNew = 4;
        return stringNew;
    }

    public void CompareSeekerToJob(List<int> seekerLicense, List<int> jobLicense)
    {
        List<Job> matchingJobs = new();
        foreach (var license in jobLicense)
        {
            if (seekerLicense.Contains(license))
            {

            }
        }
    }


}
