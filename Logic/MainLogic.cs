using MainDataBase;
namespace Logic;

public class MainLogic
{
    MainDBFunc newDB = new();


    public bool CreateNewJobSeeker(string name, int age, string email, string password, string exp)
    {
        if (password.Length >= 2 && !password.Contains(" "))//Dont forget to change!!!
        {
            Seeker newJS = new(name, age, email, password, exp);
            newDB.AddJobSeekerToDB(newJS);
            newDB.AddSeekerLicense(newDB.FindSeekerID(name), SeekerLicenseChoice());
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

    public int SeekerLicenseChoice()
    {
        int stringNew = 4;
        return stringNew;
    }
}
