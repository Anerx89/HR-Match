using Dapper;
using MySqlConnector;

namespace MainDataBase;

public class JobDB
{
    protected string sqlString = "Server=localhost;Database=hr_match;Uid=Alexander;Pwd=;";

    public void AddJobToDB(Job newJob)
    {
        var connection = new MySqlConnection(sqlString);
        string sqlQuery = "INSERT INTO job (Job_title, Job_description, Job_location, Company_id) VALUES (@job_title, @job_description, @job_location, @company_id);";
        connection.Execute(sqlQuery, newJob);
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

    public void AddJobLicenseAndEducation(int jobID, int license, int education)
    {
        var connection = new MySqlConnection(sqlString);
        string sqlQuery = $"INSERT INTO job_license (job_id, license_id) VALUES ({jobID}, {license});";
        string sqlQuery2 = $"INSERT INTO job_education (job_id, education_id) VALUES ({jobID}, {education});";
        connection.Execute(sqlQuery);
        connection.Execute(sqlQuery2);
    }


}