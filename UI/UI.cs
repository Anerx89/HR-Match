using Logic;

class UI
{
    MainLogic newLogic = new();
    SeekerLogic newSeeker = new();
    CompanyLogic newCompany = new();
    JobLogic newJob = new();

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
                RegisterNewJob();

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

        newSeeker.CreateNewJobSeeker(name, age, email, password, exp);

    }
    public void RegisterNewCompany()
    {
        Console.Write("Please enter your company name:");
        string name = Console.ReadLine();
        Console.Write("Please enter your location:");
        string location = Console.ReadLine();
        Console.Write("Please enter your working area:");
        string work_area = Console.ReadLine();
        Console.Write("Please enter your email:");
        string email = Console.ReadLine();
        Console.Write("Please enter your password:");
        string password = Console.ReadLine();

        newCompany.CreateNewCompany(name, location, work_area, email, password);

    }

    public void RegisterNewJob()
    {
        Console.Write("Please enter your company name:");
        string title = Console.ReadLine();
        Console.Write("Please enter your location:");
        string description = Console.ReadLine();
        Console.Write("Please enter your working area:");
        string location = Console.ReadLine();


        newJob.CreateNewJob(title, description, location);
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
                if (newSeeker.LoginJobSeeker(email, password))
                {

                }
                else
                {
                    Console.Write("You are not in");
                    Console.ReadLine();
                }

            }
            else if (inputKey == ConsoleKey.D2)
            {
                Console.Write("Please enter your email:");
                string email = Console.ReadLine();
                Console.Write("Please enter your password:");
                string password = Console.ReadLine();
                if (newCompany.LoginCompany(email, password))
                {
                    RegisterNewJob();
                }
                else
                {
                    Console.Write("You are not in");
                    Console.ReadLine();
                }

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