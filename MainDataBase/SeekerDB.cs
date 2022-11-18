using Dapper;
using MySqlConnector;
using ClassHolder;
namespace MainDataBase;

public class SeekerDB
{
    public static string sqlString = "Server=localhost;Database=hr_match;Uid=Alexander;Pwd=;";
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

    public List<Seeker> SearchSeekerInDB()
    {
        List<Seeker> loggedInUser = new();
        var connection = new MySqlConnection(sqlString);
        var data = connection.Query<Seeker>("SELECT seeker_id AS Seeker_id, seeker_email AS Seeker_email, password AS Password, seeker_name AS Seeker_name FROM seeker;").ToList();
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

    public List<int> GetSeekerLicense(int loggedInSeeker)
    {
        List<int> seekerLicense = new();
        var connection = new MySqlConnection(sqlString);
        var seeker = connection.Query<Seeker>("SELECT seeker_id AS Seeker_id, license_id AS License_id FROM seeker_license;").ToList();
        foreach (var user in seeker)
        {
            if (user.Seeker_id == loggedInSeeker)
            {
                seekerLicense.Add(user.License_id);
            }
        }
        return seekerLicense;
    }

    public void AddToSeeker_Job(int seekerID, int jobID)
    {
        var connection = new MySqlConnection(sqlString);
        string sqlQuery = $"INSERT INTO seeker_job (seeker_id, job_id) VALUES ({seekerID}, {jobID});";
        connection.Execute(sqlQuery);
    }

    public void RemoveFromSeeker_Job(int seekerID, int jobID)
    {
        var connection = new MySqlConnection(sqlString);
        string sqlQuery = $"DELETE FROM seeker_job WHERE seeker_id={seekerID} AND job_id={jobID};";
        connection.Execute(sqlQuery);
    }

    public void DeleteSeeker(int seekerID)
    {
        var connection = new MySqlConnection(SeekerDB.sqlString);
        connection.QueryMultiple($"DELETE FROM `seeker_job` WHERE {seekerID};DELETE FROM `seeker_education` WHERE {seekerID};DELETE FROM `seeker_license` WHERE {seekerID};DELETE FROM `seeker` WHERE seeker_id={seekerID}");
    }

    public List<Job> GetJobNameAndID(List<int> jobID)
    {
        List<Job> jobNames = new();
        foreach (var jobid in jobID)
        {
            var connection = new MySqlConnection(SeekerDB.sqlString);
            jobNames.Add(connection.QuerySingle<Job>($"SELECT job_title AS Job_title, job_id AS Job_id, job_location AS Job_location FROM job WHERE job_id={jobid};"));
        }
        return jobNames;
    }

    public List<Job> GetSeekerApplyHistory(int seekerID)
    {
        List<int> seekerApply = new();
        List<Job> seekerJobList = new();
        var connection = new MySqlConnection(SeekerDB.sqlString);
        var jobs = connection.Query<int>($"SELECT job_id FROM seeker_job WHERE seeker_id ={seekerID};").ToList();
        foreach (var id in jobs)
        {
            seekerApply.Add(id);
        }

        foreach (var id in seekerApply)
        {
            var connection2 = new MySqlConnection(SeekerDB.sqlString);
            seekerJobList.Add(connection.QuerySingle<Job>($"SELECT job_title AS Job_title, job_id AS Job_id, job_location AS Job_location FROM job WHERE job_id={id};"));
        }
        return seekerJobList;
    }
}