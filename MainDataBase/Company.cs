public class Company : IsData
{
    public string c_name { get; set; }
    public string c_location { get; set; }
    public string c_work_area { get; set; }
    public string c_email { get; set; }
    public string password { get; set; }

    public Company()
    {

    }

    public Company(string name, string location, string workArea, string email, string pass)
    {
        c_name = name;
        c_location = location;
        c_work_area = workArea;
        password = pass;
    }
}