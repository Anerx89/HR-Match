using Dapper;
using MySqlConnector;
using ClassHolder;
namespace MainDataBase;

public class SeekerDB
{
    public static string sqlString = "Server=localhost;Database=hr_match;Uid=Alexander;Pwd=;";
    public void AddJobSeekerToDB(IsData newJobSeeker)
    {
        var connection = new MySqlConnection(sqlString);
        string sqlQuery = "INSERT INTO seeker (Seeker_name, Seeker_age, Seeker_email, Password, Experience) VALUES (@seeker_name, @seeker_age, @seeker_email, @password, @experience);";
        connection.Execute(sqlQuery, newJobSeeker);
    }

    public void AddSeekerLicenseAndEducation(int seekerID, int license, int education)
    {
        var connection = new MySqlConnection(sqlString);
        string sqlQuery = $"INSERT INTO seeker_license (seeker_id, license_id) VALUES ({seekerID}, {license});";
        string sqlQuery2 = $"INSERT INTO seeker_education (seeker_id, education_id) VALUES ({seekerID}, {education});";
        connection.Execute(sqlQuery);
        connection.Execute(sqlQuery2);
    }

    public List<Seeker> SearchSeekerInDB()
    {
        List<Seeker> loggedInUser = new();
        var connection = new MySqlConnection(sqlString);
        var data = connection.Query<Seeker>("SELECT seeker_id AS Seeker_id, seeker_email AS Seeker_email, password AS Password FROM seeker;").ToList();
        foreach (Seeker j in data)
        {
            loggedInUser.Add(j);
        }
        return loggedInUser;
    }

    public int FindSeekerID(string seekerName)
    {
        int seekerID = 0;
        var connection = new MySqlConnection(sqlString);
        var data = connection.Query<Seeker>("SELECT seeker_id AS Seeker_id, seeker_name AS Seeker_name FROM seeker;").ToList();
        foreach (Seeker seeker in data)
        {
            if (seeker.Seeker_name.Contains(seekerName))
            {
                seekerID = seeker.Seeker_id;
            }
        }
        return seekerID;
    }

    public List<int> GetSeekerLicense(int loggedInSeeker)//this function needs some love.
    {
        List<int> seekerLicense = new();
        var connection = new MySqlConnection(sqlString);
        var seeker = connection.Query<Seeker>("SELECT seeker_id AS Seeker_id, license_id AS License_id FROM seeker_license;").ToList();
        foreach (var user in seeker)
        {
            if (user.Seeker_id == loggedInSeeker)
            {
                seekerLicense.Add(user.License_id);
            }
        }
        return seekerLicense;
    }
}