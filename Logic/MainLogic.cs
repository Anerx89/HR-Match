using MainDataBase;
namespace Logic;

public class MainLogic
{
    MainDBFunc newDB = new();
    int loggedInUserId = 0;

    public bool CreateNewJobSeeker(string name, int age, string email, string password, string exp)
    {
        if (password.Length >= 2 && !password.Contains(" "))//Dont forget to change!!!
        {
            Seeker newJS = new(name, age, email, password, exp);
            newDB.AddJobSeekerToDB(newJS);
            newDB.AddSeekerLicenseAndEducation(newDB.FindSeekerID(name), SeekerLicenseChoice(), SeekerEducationChoice());
            return true;
        }
        return false;
    }

    public bool CreateNewCompany(string name, string location, string workArea, string email, string password)
    {
        if (password.Length >= 2 && !password.Contains(" "))
        {
            Company newComp = new(name, location, workArea, email, password);
            newDB.AddCompanyToDB(newComp);
            return true;
        }
        return false;
    }

    public void CreateNewJob(string title, string description, string location)
    {
        Job newJob = new(loggedInUserId, title, description, location);
        newDB.AddJobToDB(newJob);
    }
    public bool LoginJobSeeker(string email, string password)
    {
        foreach (var item in newDB.SearchSeekerInDB())
        {
            if (item.Seeker_email.Contains(email) && item.Password.Contains(password))
            {
                loggedInUserId = item.Seeker_id;
                return true;
            }
        }
        return false;
    }
    public bool LoginCompany(string email, string password)
    {
        foreach (var item in newDB.SearchCompanyInDB())
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
        int stringNew = 4;
        return stringNew;
    }
    public int SeekerEducationChoice()
    {
        int stringNew = 4;
        return stringNew;
    }
}
