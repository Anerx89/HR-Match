using Logic;
using ClassHolder;
using MainDataBase;

public class CompanyLogic
{
    CompanyDB newCompanyDB = new();
    public static int loggedInCompanyId = 0;

    public bool CreateNewCompany(string name, string location, string workArea, string email, string password)
    {
        if (password.Length >= 2 && !password.Contains(" "))
        {
            Company newComp = new(name, location, workArea, email, password);
            newCompanyDB.AddCompanyToDB(newComp);
            return true;
        }
        return false;
    }

    public bool LoginCompany(string email, string password)
    {
        foreach (var item in newCompanyDB.SearchCompanyInDB())
        {
            if (item.C_email.Contains(email) && item.Password.Contains(password))
            {
                loggedInCompanyId = item.C_id;
                return true;
            }
        }
        return false;
    }
}