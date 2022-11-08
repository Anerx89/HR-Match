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
            }
        }
        return seekerID;
    }
    public int FindJobID(int compID)
    {
        int jobID = 0;
        var connection = new MySqlConnection(sqlString);
        var data = connection.Query<Job>("SELECT job_id AS Job_id, company_id AS Company_id FROM job;").ToList();
        foreach (Job job in data)
        {
            if (job.Company_id == compID)
            {
                jobID = job.Job_id;
            }
        }
        return jobID;
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

    public void AddJobLicenseAndEducation(int jobID, int license, int education)
    {
        var connection = new MySqlConnection(sqlString);
        string sqlQuery = $"INSERT INTO job_license (job_id, license_id) VALUES ({jobID}, {license});";
        string sqlQuery2 = $"INSERT INTO job_education (job_id, education_id) VALUES ({jobID}, {education});";
        connection.Execute(sqlQuery);
        connection.Execute(sqlQuery2);
    }

}
