using Dapper;
using MySqlConnector;

namespace MainDataBase;

public class SeekerDB
{
    protected string sqlString = "Server=localhost;Database=hr_match;Uid=Alexander;Pwd=;";

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

    public void CompareJobToSeeker()//this function needs some love.
    {
        List<int> firstSearch = new();
        var connection = new MySqlConnection(sqlString);
        var jobs = connection.Query<Job>("SELECT job_id AS Job_id, license_id AS License_id FROM job_license;").ToList();
        var seeker = connection.Query<Seeker>("SELECT seeker_id AS Seeker_id, license_id AS License_id FROM seeker_license;").ToList();
        foreach (var job in jobs)
        {
            foreach (var User in seeker)
            {
                if (job.License_id == User.License_id)
                {
                    firstSearch.Add(job.Job_id);
                }
            }
        }
        foreach (var item in firstSearch)
        {
            Console.WriteLine(item.ToString());
        }
        Console.ReadLine();
    }
}