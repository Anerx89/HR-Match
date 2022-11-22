namespace Logic;
using ClassHolder;
using MainDataBase;

public class SeekerLogic
{

    SeekerDB seekerDB = new();
    JobDB newJobDB = new();
    public static int loggedInSeekerId = 0;

    public bool CreateNewJobSeeker(string name, int age, string email, string password, string exp, int license, int education)
    {
        if (password.Length >= 2 && !password.Contains(" "))
        {
            Seeker newJS = new(name, age, email, password, exp);
            seekerDB.AddJobSeekerToDB(newJS);
            seekerDB.AddSeekerLicenseAndEducation(seekerDB.FindSeekerID(name), license, education);
            return true;
        }
        return false;
    }

    public bool LoginJobSeeker(string email, string password)
    {
        foreach (var item in seekerDB.SearchSeekerInDB())
        {
            if (item.Seeker_email.Equals(email) && item.Password.Equals(password))
            {
                loggedInSeekerId = item.Seeker_id;
                seekerDB.GetSeekerLicense(loggedInSeekerId);
                newJobDB.GetJobRequirements(loggedInSeekerId);
                return true;
            }
        }
        return false;
    }
}