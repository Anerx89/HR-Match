using Logic;
using Dapper;
using MySqlConnector;
using ClassHolder;
using MainDataBase;

public class CompanyLogic
{
    CompanyDB newCompanyDB = new();
    public static int loggedInCompanyId = 0;

    public bool CreateNewCompany(string name, string location, string workArea, string email, string password) // Creates a new company.
    {
        if (password.Length >= 6 && !password.Contains(" "))
        {
            Company newComp = new(name, location, workArea, email, password);
            newCompanyDB.AddCompanyToDB(newComp);
            return true;
        }
        return false;
    }

    public bool LoginCompany(string email, string password) //Checks if company with entered email and password exists in db and if yes returns true.
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