using Logic;

class UI
{
    MainLogic newLogic = new();
    public void Menu()
    {
        bool isRunning = true;
        while (isRunning == true)
        {
            Console.Clear();
            Console.WriteLine("|1| - Log in\n|2| - Register account\n|3| - Register company\n|Q| - To exit any time");
            ConsoleKey inputKey = Console.ReadKey().Key;


            if (inputKey == ConsoleKey.D1)
            {
                LoginMenu();
            }
            else if (inputKey == ConsoleKey.D2)
            {
                RegisterNewJobSeeker();

            }
            else if (inputKey == ConsoleKey.D3)
            {
                RegisterNewCompany();

            }
            else if (inputKey == ConsoleKey.Q)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again");
            }
        }
    }

    public void RegisterNewJobSeeker()
    {
        Console.Write("Please enter your name:");
        string name = Console.ReadLine();
        Console.Write("Please enter your age:");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Please enter your email:");
        string email = Console.ReadLine();
        Console.Write("Please enter your password:");
        string password = Console.ReadLine();
        Console.Write("Please enter your experience:");
        string exp = Console.ReadLine();

        newLogic.CreateNewJobSeeker(name, age, email, password, exp);

    }
    public void RegisterNewCompany()
    {

    }

    public void LoginMenu()
    {
        bool isRunning = true;
        while (isRunning == true)
        {
            Console.Clear();
            Console.WriteLine("|1| - Log in User\n|2| - Login Company");
            ConsoleKey inputKey = Console.ReadKey().Key;


            if (inputKey == ConsoleKey.D1)
            {
                Console.Write("Please enter your email:");
                string email = Console.ReadLine();
                Console.Write("Please enter your password:");
                string password = Console.ReadLine();
                if (newLogic.LoginJobSeeker(email, password))
                {
                    Console.Write("You are in");
                    Console.ReadLine();
                }
                else
                {
                    Console.Write("You are not in");
                    Console.ReadLine();
                }

            }
            else if (inputKey == ConsoleKey.D2)
            {


            }
            else if (inputKey == ConsoleKey.Q)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again");
            }
        }
    }
    public void LoginUser()
    {

    }
    public void LoginCompany()
    {

    }
}