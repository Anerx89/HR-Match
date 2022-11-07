using Dapper;
using MySqlConnector;

namespace MainDataBase;
public class MainDBFunc
{
    protected string sqlString = "Server=localhost;Database=hr_match;Uid=Alexander;Pwd=;";

    public void AddJobSeekerToDB(IsData newJobSeeker)
    {
        var connection = new MySqlConnection(sqlString);
        string sqlQuery = "INSERT INTO seeker (seeker_name, seeker_age, seeker_email, password, experience) VALUES (@seeker_name, @seeker_age, @seeker_email, @password, @experience);";
        var rowsAffected = connection.Execute(sqlQuery, newJobSeeker);
    }
    public void AddSeekerLicense(int seekerID, int license)
    {
        var connection = new MySqlConnection(sqlString);
        string sqlQuery = $"INSERT INTO seeker_license (seeker_id, license_id) VALUES ({seekerID}, {license});";
        var rowsAffected = connection.Execute(sqlQuery);
    }
    public void AddCompanyToDB(IsData newComp)
    {
        var connection = new MySqlConnection(sqlString);
        string sqlQuery = "INSERT INTO company (c_name, c_location, c_work_area, c_email, password) VALUES (@c_name, @c_location, @c_work_area, @c_email, @password);";
        var rowsAffected = connection.Execute(sqlQuery, newComp);
    }
    public void AddJobToDB(IsData newJob)
    {
        var connection = new MySqlConnection(sqlString);
        string sqlQuery = "INSERT INTO job (job_title, job_description, job_location) VALUES (@job_title, @job_description, @job_location);";
        var rowsAffected = connection.Execute(sqlQuery, newJob);
    }

    public List<Seeker> SearchSeekerInDB()
    {
        List<Seeker> loggedInUser = new();
        var connection = new MySqlConnection(sqlString);
        var data = connection.Query<Seeker>("SELECT seeker_id, seeker_email, password FROM seeker;").ToList();
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
        var data = connection.Query<Seeker>("SELECT seeker_id, seeker_name FROM seeker;").ToList();
        foreach (Seeker seeker in data)
        {
            if (seeker.seeker_name.Contains(seekerName))
            {
                seekerID = seeker.seeker_id;
                Console.WriteLine(seekerID);
                Console.ReadLine();
            }
        }
        return seekerID;
    }
    public List<Company> SearchCompanyInDB()
    {
        List<Company> loggedInCompany = new();
        var connection = new MySqlConnection(sqlString);
        var data = connection.Query<Company>("SELECT seeker_id, seeker_email, password FROM job_seeker;").ToList();
        foreach (Company c in data)
        {
            loggedInCompany.Add(c);
        }
        return loggedInCompany;
    }
    public void CompareJobToSeeker()
    {

    }

}
