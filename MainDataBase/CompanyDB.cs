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

    public void DeleteJobDB(int companyID, int jobID)
    {
        var connection = new MySqlConnection(SeekerDB.sqlString);
        connection.QueryMultiple($"DELETE FROM `seeker_job` WHERE job_id={jobID};DELETE FROM `job_education` WHERE job_id={jobID};DELETE FROM `job_license` WHERE job_id={jobID};DELETE FROM `job` WHERE job.job_id={jobID};");
    }

    public void DeleteCompany(int companyID)
    {
        var connection = new MySqlConnection(SeekerDB.sqlString);
        connection.QueryMultiple($"DELETE FROM `seeker_job` WHERE {companyID};DELETE FROM `job_education` WHERE {companyID};DELETE FROM `job_license` WHERE {companyID};DELETE FROM `job` WHERE job.company_id={companyID};DELETE FROM `company` WHERE company.c_id={companyID}");
    }
}