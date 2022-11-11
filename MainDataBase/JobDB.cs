using Dapper;
using MySqlConnector;
using MainDataBase;

public class JobDB
{

    public void AddJobToDB(Job newJob)
    {
        var connection = new MySqlConnection(SeekerDB.sqlString);
        string sqlQuery = "INSERT INTO job (Job_title, Job_description, Job_location, Company_id) VALUES (@job_title, @job_description, @job_location, @company_id);";
        connection.Execute(sqlQuery, newJob);
    }

    public int FindJobID(int compID)
    {
        int jobID = 0;
        var connection = new MySqlConnection(SeekerDB.sqlString);
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
        var connection = new MySqlConnection(SeekerDB.sqlString);
        string sqlQuery = $"INSERT INTO job_license (job_id, license_id) VALUES ({jobID}, {license});";
        string sqlQuery2 = $"INSERT INTO job_education (job_id, education_id) VALUES ({jobID}, {education});";
        connection.Execute(sqlQuery);
        connection.Execute(sqlQuery2);
    }

    public List<int> GetJobRequirements(int seekerID)
    {
        List<int> jobID = new();
        var connection = new MySqlConnection(SeekerDB.sqlString);
        var jobs = connection.Query<Job>($"SELECT job_id AS Job_id FROM job_license jl INNER JOIN seeker_license sl ON jl.license_id = sl.license_id WHERE seeker_id={seekerID};").ToList();
        var education = connection.Query<Job>($"SELECT job_id AS Job_id FROM job_education jl INNER JOIN seeker_education sl ON jl.education_id = sl.education_id WHERE seeker_id={seekerID};").ToList();

        foreach (var job in jobs)
        {
            jobID.Add(job.Job_id);
        }
        foreach (var ed in education)
        {
            jobID.Add(ed.Job_id);
        }
        return jobID;
    }
}