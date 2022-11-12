using Dapper;
using MySqlConnector;
using MainDataBase;
using ClassHolder;

public class CompanyDB
{

    public void AddCompanyToDB(IsData newComp)
    {
        var connection = new MySqlConnection(SeekerDB.sqlString);
        string sqlQuery = "INSERT INTO company (C_name, C_location, C_work_area, C_email, Password) VALUES (@c_name, @c_location, @c_work_area, @c_email, @password);";
        connection.Execute(sqlQuery, newComp);
    }

    public List<Company> SearchCompanyInDB()
    {
        List<Company> loggedInCompany = new();
        var connection = new MySqlConnection(SeekerDB.sqlString);
        var data = connection.Query<Company>("SELECT c_id AS C_id, c_email AS C_email, password AS Password FROM company;").ToList();
        foreach (Company c in data)
        {
            loggedInCompany.Add(c);
        }
        return loggedInCompany;
    }

    public List<Seeker> GetSeekersThatApplyToJob(int companyID)
    {
        List<Seeker> seekerApply = new();
        var connection = new MySqlConnection(SeekerDB.sqlString);
        var seekers_job = connection.Query<Seeker>($"SELECT seeker_id as Seeker_id FROM seeker_job sj INNER JOIN job j ON sj.job_id = j.job_id WHERE j.company_id ={companyID};").ToList();
        var seekers = connection.Query<Seeker>($"SELECT * FROM `seeker`");
        foreach (var seekerId in seekers_job)
        {
            foreach (var seeker in seekers)
            {
                if (seekerId.Seeker_id == seeker.Seeker_id)
                {
                    seekerApply.Add(seeker);
                }
            }
        }
        return seekerApply;
    }

    public void DeleteJobDB(int companyID, int jobID)
    {
        var connection = new MySqlConnection(SeekerDB.sqlString);
        connection.QueryMultiple($"DELETE FROM `job_education` WHERE {jobID};DELETE FROM `job_license` WHERE {jobID};DELETE FROM `job` WHERE job.job_id={jobID};");
    }





    public List<Job> ListCompanyJobs(int companyID)
    {
        var connection = new MySqlConnection(SeekerDB.sqlString);
        var jobs = connection.Query<Job>($"SELECT * FROM `job` WHERE job.company_id={companyID}").ToList();
        return jobs;
    }



}