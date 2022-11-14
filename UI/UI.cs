using Logic;
using MainDataBase;

class UI
{
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
        Console.Write("Please enter job title:");
        string title = Console.ReadLine();
        Console.Write("Please enter job location:");
        string description = Console.ReadLine();
        Console.Write("Please enter working area:");
        string location = Console.ReadLine();
        int license = ChooseLicenseToJob();
        int education = ChooseEducationToJob();


        newJob.CreateNewJob(title, description, location, license, education);
    }
    public int ChooseLicenseToJob()
    {
        int licenseType = 0;
        while (true)
        {
            Console.WriteLine("Choose a  driver license requirement for the job: ");
            Console.WriteLine("|1| - A\n|2| - B\n|3| - C\n|3| - No Requirements");
            ConsoleKey licenseChoice = Console.ReadKey().Key;
            if (licenseChoice == ConsoleKey.D1)
            {
                licenseType = (int)License.A;
                break;
            }
            else if (licenseChoice == ConsoleKey.D2)
            {
                licenseType = (int)License.B;
                break;
            }
            else if (licenseChoice == ConsoleKey.D3)
            {
                licenseType = (int)License.C;
                break;
            }
            else if (licenseChoice == ConsoleKey.D4)
            {
                licenseType = (int)License.none;
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input. Try again.");
            }
        }
        return licenseType;
    }
    public int ChooseEducationToJob()
    {
        int educationType = 0;
        while (true)
        {
            Console.WriteLine("Choose a  driver license requirement for the job: ");
            Console.WriteLine("|1| - Gymnasium\n|2| - Universitet\n|3| - Yrkeshögskola\n|4| - Folkhögskola\n|5| - No Requirements");
            ConsoleKey educationChoice = Console.ReadKey().Key;
            if (educationChoice == ConsoleKey.D1)
            {
                educationType = (int)Education.Gymnasium;
                break;
            }
            else if (educationChoice == ConsoleKey.D2)
            {
                educationType = (int)Education.Universitet;
                break;
            }
            else if (educationChoice == ConsoleKey.D3)
            {
                educationType = (int)Education.Yrkeshögskola;
                break;
            }
            else if (educationChoice == ConsoleKey.D4)
            {
                educationType = (int)Education.Folkhögskola;
                break;
            }
            else if (educationChoice == ConsoleKey.D5)
            {
                educationType = (int)Education.none;
            }
            else
            {
                Console.WriteLine("Invalid Input. Try again.");
            }
        }
        return educationType;
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
                    Console.Clear();
                    bool SeekerMenu = true;
                    while (SeekerMenu == true)
                    {
                        Console.Clear();
                        Console.WriteLine("|1| - Show job history\n|2| - Apply for job");
                        ConsoleKey seekerMenuKey = Console.ReadKey().Key;
                        if (seekerMenuKey == ConsoleKey.D1)
                        {
                            SeekerDB seeker_job = new();
                            foreach (var job in seeker_job.GetSeekerApplyHistory(SeekerLogic.loggedInSeekerId))
                            {
                                Console.WriteLine(job);
                            }
                            Console.ReadKey();

                        }
                        else if (seekerMenuKey == ConsoleKey.D2)
                        {
                            SeekerDB seeker_job = new();
                            JobDB job_seeker = new();

                            foreach (var job in job_seeker.GetJobRequirements(SeekerLogic.loggedInSeekerId))
                            {
                                Console.WriteLine(job);
                            }

                            Console.WriteLine("Enter the ID of the job you want to apply for");
                            int SeekerApply = Convert.ToInt32(Console.ReadLine());
                            seeker_job.AddToSeeker_Job(SeekerLogic.loggedInSeekerId, SeekerApply);
                        }
                    }


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
                    CompanyDB newCompanyDB = new();
                    newCompanyDB.GetSeekersThatApplyToJob(CompanyLogic.loggedInCompanyId);
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

    public void SeekerMenu()
    {

    }

    public void LoginUser()
    {

    }
    public void LoginCompany()
    {

    }
}