public class JobSeeker : IsData
{
    public int seeker_id { get; set; }
    public string seeker_name { get; set; }
    public int seeker_age { get; set; }
    public string seeker_email { get; set; }
    public string password { get; set; }

    public JobSeeker()
    {

    }
    public JobSeeker(string name, int age, string email, string pass)
    {
        seeker_name = name;
        seeker_age = age;
        seeker_email = email;
        password = pass;
    }
    public override string ToString()
    {
        return $"{seeker_name} {seeker_age}";
    }

}