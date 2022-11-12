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


        newJob.CreateNewJob(title, description, location);
    }
    public int ChooseLicenseToJob()
    {
        int licenseType = 0;
        while (true)
        {
            Console.WriteLine("Choose a  driver license requirement for the job: ");
            Console.WriteLine("|1| - A\n|2| - B\n|3| - C\n|3| - No Requirements.");
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
                Console.Clear();
                Console.Write("Please enter your email:");
                string email = Console.ReadLine();
                Console.Write("Please enter your password:");
                string password = Console.ReadLine();
                if (newCompany.LoginCompany(email, password))
                {
                    bool companyLoop = true;
                    while (companyLoop)
                    {


                        CompanyDB newCompanyDB = new();
                        Console.Clear();
                        Console.WriteLine("|1| - Register new job\n|2| - See applications\n|3| - Delete job\n|4| - Delete account\n|Q| - To exit any time");
                        ConsoleKey input = Console.ReadKey().Key;


                        if (input == ConsoleKey.D1)
                        {
                            Console.Clear();
                            Console.WriteLine("register");
                            RegisterNewJob();
                            ChooseLicenseToJob();
                            Console.ReadLine();
                        }
                        else if (input == ConsoleKey.D2)
                        {
                            Console.Clear();
                            Console.WriteLine("List of Applicants");
                            foreach (var seeker in newCompanyDB.GetSeekersThatApplyToJob(CompanyLogic.loggedInCompanyId))
                            {
                                Console.WriteLine(seeker.ToString());
                            }
                            Console.ReadLine();
                        }
                        else if (input == ConsoleKey.D3)
                        {

                            Console.Clear();
                            Console.WriteLine("Jobs to delete:");
                            foreach (var job in newCompanyDB.ListCompanyJobs(CompanyLogic.loggedInCompanyId))
                            {
                                Console.WriteLine(job.ToString());
                            }
                            Console.Write("Please enter id to delete: ");
                            int jobId = Convert.ToInt32(Console.ReadLine());
                            newCompanyDB.DeleteJobDB(CompanyLogic.loggedInCompanyId, jobId);
                            Console.Write("Delete successful.");
                            Console.ReadLine();
                        }
                        else if (input == ConsoleKey.D4)
                        {
                            Console.Clear();
                            Console.WriteLine("Are you sure you want to delete your account?");
                            Console.WriteLine("|1| - Delete\n|2| - Go Back\n");
                            ConsoleKey choice = Console.ReadKey().Key;
                            if (choice == ConsoleKey.D1)
                            {
                                Console.Clear();
                                newCompanyDB.DeleteCompany(CompanyLogic.loggedInCompanyId);
                                Console.WriteLine("Account is deleted.\nPress any key to go back to main menu");
                                Console.ReadLine();
                                Menu();
                            }
                        }
                        else if (input == ConsoleKey.Q)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please try again");
                        }
                    }

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