using Dapper;
using MySqlConnector;

namespace MainDataBase;
public class MainDBFunc
{

    public void AddJobSeekerToDB(IsData newJobSeeker)
    {
        var connection = new MySqlConnection("Server=localhost;Database=hr_match;Uid=Alexander;Pwd=;");
        string sqlQuery = "INSERT INTO job_seeker (seeker_name, seeker_age, seeker_email, password) VALUES (@seeker_name, @seeker_age, @seeker_email, @password);";
        var rowsAffected = connection.Execute(sqlQuery, newJobSeeker);

    }
    public void AddCompanyToDB(IsData newComp)
    {
        var connection = new MySqlConnection("Server=localhost;Database=hr_match;Uid=Alexander;Pwd=;");
        string sqlQuery = "INSERT INTO company (c_name, c_location, c_work_area, c_email, password) VALUES (@c_name, @c_location, @c_work_area, @c_email, @password);";
        var rowsAffected = connection.Execute(sqlQuery, newComp);
    }
    public void AddJobToDB(IsData newJob)
    {
        var connection = new MySqlConnection("Server=localhost;Database=hr_match;Uid=Alexander;Pwd=;");
        string sqlQuery = "INSERT INTO job (job_title, job_description, job_location) VALUES (@job_title, @job_description, @job_location);";
        var rowsAffected = connection.Execute(sqlQuery, newJob);
    }

    public List<JobSeeker> SearchSeekerInDB()
    {
        List<JobSeeker> loggedInUser = new();
        var connection = new MySqlConnection("Server=localhost;Database=hr_match;Uid=Alexander;Pwd=;");
        var data = connection.Query<JobSeeker>("SELECT seeker_id, seeker_email, password FROM job_seeker;").ToList();
        foreach (JobSeeker j in data)
        {
            loggedInUser.Add(j);
        }
        return loggedInUser;
    }
    public List<Company> SearchCompanyInDB()
    {
        List<Company> loggedInCompany = new();
        var connection = new MySqlConnection("Server=localhost;Database=hr_match;Uid=Alexander;Pwd=;");
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
