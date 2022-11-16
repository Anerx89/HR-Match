using Logic;
using Dapper;
using MySqlConnector;
using ClassHolder;
using MainDataBase;

public class CompanyLogic
{
    CompanyDB newCompanyDB = new();
    public static int loggedInCompanyId = 0;

    public bool CreateNewCompany(string name, string location, string workArea, string email, string password)
    {
        if (password.Length >= 2 && !password.Contains(" "))
        {
            Company newComp = new(name, location, workArea, email, password);
            newCompanyDB.AddCompanyToDB(newComp);
            return true;
        }
        return false;
    }

    public bool LoginCompany(string email, string password)
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

    public List<Job> ListCompanyJobs(int companyID)
    {
        var connection = new MySqlConnection(SeekerDB.sqlString);
        var jobs = connection.Query<Job>($"SELECT * FROM `job` WHERE job.company_id={companyID}").ToList();
        return jobs;
    }
}