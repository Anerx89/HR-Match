using Dapper;
using MySqlConnector;


namespace MainDataBase;
public class MainDBFunc
{
    public static string sqlString = "Server=localhost;Database=hr_match;Uid=Alexander;Pwd=;";

    public List<int> GetJobLicense(int seekerID)
    {
        List<int> jobID = new();
        var connection = new MySqlConnection(sqlString);
        var jobs = connection.Query<Job>($"SELECT job_id AS Job_id FROM job_license jl INNER JOIN seeker_license sl ON jl.license_id = sl.license_id WHERE seeker_id={seekerID};").ToList();

        foreach (var job in jobs)
        {
            jobID.Add(job.Job_id);
            Console.WriteLine(job.Job_id.ToString());
        }
        Console.ReadLine();
        return jobID;
    }


}
