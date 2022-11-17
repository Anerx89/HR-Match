namespace ClassHolder;

public class Seeker : IsData
{
    public int Seeker_id { get; set; }
    public int Job_id { get; set; }
    public int License_id { get; set; }
    public string Seeker_name { get; set; }
    public int Seeker_age { get; set; }
    public string Seeker_email { get; set; }
    public string Password { get; set; }
    public string Experience { get; set; }


    public Seeker()
    {

    }

    public Seeker(string name, int age, string email, string pass, string exp)
    {
        Seeker_name = name;
        Seeker_age = age;
        Seeker_email = email;
        Password = pass;
        Experience = exp;
    }
    public override string ToString()
    {
        return $"{Seeker_name} {Job_id}";
    }

}