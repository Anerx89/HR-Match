using Logic;
using ClassHolder;
using MainDataBase;

public class SeekerLogic
{

    SeekerDB seekerDB = new();
    MainDBFunc newDB = new();
    int loggedInSeekerId = 0;

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
    public bool LoginJobSeeker(string email, string password)
    {
        foreach (var item in seekerDB.SearchSeekerInDB())
        {
            if (item.Seeker_email.Contains(email) && item.Password.Contains(password))
            {
                loggedInSeekerId = item.Seeker_id;
                seekerDB.GetSeekerLicense(loggedInSeekerId);
                newDB.GetJobLicense(loggedInSeekerId);
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

}