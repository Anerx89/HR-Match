using ClassHolder;
public class Job
{
    public int Company_id { get; set; }
    public int Job_id { get; set; }
    public int License_id { get; set; }
    public string Job_title { get; set; }
    public string Job_description { get; set; }
    public string Job_location { get; set; }

    public Job()
    {

    }
    public Job(int company_id, string title, string description, string location)
    {
        Company_id = company_id;
        Job_title = title;
        Job_description = description;
        Job_location = location;
    }
    public override string ToString()
    {
        return $"Job ID | {Job_id} | Title: {Job_title} \nLocation: {Job_location} || Description: {Job_description}\n";
    }
}