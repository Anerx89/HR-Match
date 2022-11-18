using Logic;
using Dapper;
using MySqlConnector;
using ClassHolder;
using MainDataBase;

public class CompanyLogic
{
    CompanyDB newCompanyDB = new();
    public static int loggedInCompanyId = 0;

    public bool CreateNewCompany(string name, string location, string workArea, string email, string password) // Creates a new company.
    {
        if (password.Length >= 6 && !password.Contains(" "))
        {
            Company newComp = new(name, location, workArea, email, password);
            newCompanyDB.AddCompanyToDB(newComp);
            return true;
        }
        return false;
    }

    public bool LoginCompany(string email, string password) //Checks if company with entered email and password exists in db and if yes returns true.
    {
        foreach (var item in SearchCompanyInDB())
        {
            if (item.C_email.Contains(email) && item.Password.Contains(password))
            {
                loggedInCompanyId = item.C_id;
                return true;
            }
        }
        return false;
    }

    public List<Company> SearchCompanyInDB() //Searches trough db for all companies.
    {
        var connection = new MySqlConnection(SeekerDB.sqlString);
        var data = connection.Query<Company>("SELECT c_id AS C_id, c_email AS C_email, password AS Password FROM company;").ToList();
        return data;
    }

    public List<Seeker_job> GetSeekersThatApplyToCompany(int companyID) //Searches after appliances that have applied to logged in company jobs.
    {
        List<Seeker> seekerApply = new();
        var connection = new MySqlConnection(SeekerDB.sqlString);
        var seeker = connection.Query<Seeker_job>($"SELECT * FROM seeker_job sj INNER JOIN job j ON sj.job_id = j.job_id WHERE j.company_id ={companyID};").ToList();
        return seeker;
    }

    public List<Job> ListCompanyJobs(int companyID) // Searches for logged in company jobs and returns a list.
    {
        var connection = new MySqlConnection(SeekerDB.sqlString);
        var jobs = connection.Query<Job>($"SELECT * FROM `job` WHERE job.company_id={companyID}").ToList();
        return jobs;
    }
}