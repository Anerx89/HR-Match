using Dapper;
using MySqlConnector;
using MainDataBase;

public class CompanyDB
{
    protected string sqlString = "Server=localhost;Database=hr_match;Uid=Alexander;Pwd=;";

    public void AddCompanyToDB(IsData newComp)
    {
        var connection = new MySqlConnection(sqlString);
        string sqlQuery = "INSERT INTO company (C_name, C_location, C_work_area, C_email, Password) VALUES (@c_name, @c_location, @c_work_area, @c_email, @password);";
        connection.Execute(sqlQuery, newComp);
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


}