using MainDataBase;
namespace Logic;

public class MainLogic
{
    MainDBFunc newDB = new();

    public void CreateNewJobSeeker(string name, int age, string email, string password)
    {
        JobSeeker newJS = new(name, age, email, password);
        newDB.AddJobSeekerToDB(newJS);
    }

    public void CreateNewCompany(string name, string location, string workArea, string email, string password)
    {
        Company newComp = new(name, location, workArea, email, password);
        newDB.AddEmployerToDB(newComp);
    }

    public void CreateNewJob()
    {

    }
    public bool LoginUser(string email, string password)
    {

        foreach (var item in newDB.SearchInDB())
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
