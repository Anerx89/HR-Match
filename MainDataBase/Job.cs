public class Job : IsData
{
    public string job_title { get; set; }
    public string job_description { get; set; }
    public string job_location { get; set; }
    public string password { get; set; }
    public string email { get; set; }

    public Job(string title, string description, string location)
    {
        job_title = title;
        job_description = description;
        job_location = location;
    }
}