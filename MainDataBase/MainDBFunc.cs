using Dapper;
using MySqlConnector;

namespace MainDataBase;
public class MainDBFunc
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
    public void AddCompanyToDB(IsData newComp)
    {
        var connection = new MySqlConnection(sqlString);
        string sqlQuery = "INSERT INTO company (C_name, C_location, C_work_area, C_email, Password) VALUES (@c_name, @c_location, @c_work_area, @c_email, @password);";
        connection.Execute(sqlQuery, newComp);
    }
    public void AddJobToDB(Job newJob)
    {
        var connection = new MySqlConnection(sqlString);
        string sqlQuery = "INSERT INTO job (Job_title, Job_description, Job_location, Company_id) VALUES (@job_title, @job_description, @job_location, @company_id);";
        connection.Execute(sqlQuery, newJob);
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
                Console.WriteLine(seekerID);
                Console.ReadLine();
            }
        }
        return seekerID;
    }
    public int FindJobID()
    {
        int companyAndJobID = 0;
        var connection = new MySqlConnection(sqlString);
        var data = connection.Query<Job>("SELECT job_id AS Job_id FROM job;").ToList();
        foreach (Job job in data)
        {

        }

        return companyAndJobID;
    }
    public List<Company> SearchCompanyInDB()
    {
        List<Company> loggedInCompany = new();
        var connection = new MySqlConnection(sqlString);
        var data = connection.Query<Company>("SELECT c_id AS C_id, c_email AS C_email, password AS Password FROM company;").ToList();
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
