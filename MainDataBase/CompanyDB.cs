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

    public List<int> GetSeekersThatApplyToJob(int companyID)
    {
        List<int> seekerApply = new();
        var connection = new MySqlConnection(SeekerDB.sqlString);
        var seekers = connection.Query<Seeker>($"SELECT seeker_id as Seeker_id FROM seeker_job sj INNER JOIN job j ON sj.job_id = j.job_id WHERE j.company_id ={companyID};").ToList();

        foreach (var seeker in seekers)
        {
            seekerApply.Add(seeker.Seeker_id);
        }
        return seekerApply;
    }


}