using MainDataBase;
namespace Logic;

public class MainLogic
{
    MainDBFunc newDB = new();


    public bool CreateNewJobSeeker(string name, int age, string email, string password)
    {
        if (password.Length >= 8 && !password.Contains(" "))
        {
            JobSeeker newJS = new(name, age, email, password);
            newDB.AddJobSeekerToDB(newJS);
            return true;
        }
        return false;
    }

    public bool CreateNewCompany(string name, string location, string workArea, string email, string password)
    {
        if (password.Length >= 8 && !password.Contains(" "))
        {
            Company newComp = new(name, location, workArea, email, password);
            newDB.AddCompanyToDB(newComp);
            return true;
        }
        return false;
    }

    public void CreateNewJob()
    {

    }
    public bool LoginJobSeeker(string email, string password)
    {

        foreach (var item in newDB.SearchSeekerInDB())
        {
            if (item.seeker_email.Contains(email) && item.password.Contains(password))
            {
                return true;
            }
        }
        return false;
    }
    public void LoginCompany()
    {

    }
}
