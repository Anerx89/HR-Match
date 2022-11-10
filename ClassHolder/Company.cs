using ClassHolder;
public class Company : IsData
{
    public int C_id { get; set; }
    public string C_name { get; set; }
    public string C_location { get; set; }
    public string C_work_area { get; set; }
    public string C_email { get; set; }
    public string Password { get; set; }

    public Company()
    {

    }

    public Company(string name, string location, string workArea, string email, string pass)
    {
        C_name = name;
        C_location = location;
        C_work_area = workArea;
        C_email = email;
        Password = pass;
    }

    public override string ToString()
    {
        return $"Company name: {C_name}, Company Location: {C_location}, Company Working Area: {C_work_area}";
    }
}