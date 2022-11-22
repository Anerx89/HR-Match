using Logic;
using MainDataBase;
using ClassHolder;

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
            Console.WriteLine("Welcome to A tier HR Match making!\n");
            Console.WriteLine("|1| - Log in\n|2| - Register account\n|3| - Register company\n|Q| - Exit");
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
        Console.Clear();
        Console.Write("Please enter your name:");
        string name = CheckIfNullOrWhiteSpace(Console.ReadLine());
        bool isAlpha = name.All(Char.IsLetter);
        if (isAlpha)
        {
            Console.WriteLine($"Welcome, {name}!\n");
            Console.ReadLine();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Only letters are allowed!\nPress any key to return");
            Console.ReadLine();
        }
        Console.Write("Please enter your age:");
        int age = isNumbers(Console.ReadLine());
        Console.Write("Please enter your email:");
        string email = Console.ReadLine();

        bool passwordSuccess = false;
        string password = "";
        while (!passwordSuccess)
        {
            Console.Write("Please enter your password:");
            string p = Console.ReadLine();
            bool pwIsAlpha = p.Contains(" ");
            if (!pwIsAlpha)
            {
                password = p;
                passwordSuccess = true;
            }
            else
            {
                Console.WriteLine("You cant have spaces in your password.\nTry again.");
                Console.ReadLine();
            }

        }

        Console.Write("Write a short summary of your job experience:");
        string exp = Console.ReadLine();
        int license = ChooseLicenseToSeeker();
        int education = ChooseEducationToSeeker();

        newSeeker.CreateNewJobSeeker(name, age, email, password, exp, license, education);
    }

    public void RegisterNewCompany() //Takes in all information needed from hr user and sends it to companyLogic.
    {
        Console.Clear();
        Console.Write("Please enter your company name:");
        string name = CheckIfNullOrWhiteSpace(Console.ReadLine());
        Console.Write("Please enter your location:");
        string location = CheckIfNullOrWhiteSpace(Console.ReadLine());
        Console.Write("Please enter your working area:");
        string work_area = CheckIfNullOrWhiteSpace(Console.ReadLine());
        Console.Write("Please enter your email:");
        string email = CheckIfNullOrWhiteSpace(Console.ReadLine().ToLower());
        bool passwordSuccess = false;
        string password = "";
        while (!passwordSuccess)
        {
            Console.Write("Please enter your password,\nPassword needs to be minimum 6 characters:");
            string p = Console.ReadLine();
            int passwordLength = p.Length;
            bool isAlpha = p.Contains(" ");
            if (!isAlpha && passwordLength >= 6)
            {
                password = p;
                passwordSuccess = true;
            }
            else
            {
                Console.WriteLine("Password was to short or contained a space.\nTry again.");
                Console.ReadLine();
            }
        }

        newCompany.CreateNewCompany(name, location, work_area, email, password);

    }

    public void RegisterNewJob()
    {
        Console.Clear();
        Console.Write("Please enter job title:");
        string title = CheckIfNullOrWhiteSpace(Console.ReadLine());
        Console.Write("Please enter job location:");
        string description = CheckIfNullOrWhiteSpace(Console.ReadLine());
        Console.Write("Please enter working area:");
        string location = CheckIfNullOrWhiteSpace(Console.ReadLine());
        int license = ChooseLicenseToJob();
        int education = ChooseEducationToJob();


        newJob.CreateNewJob(title, description, location, license, education);
    }

    public int ChooseLicenseToSeeker()
    {
        int licenseType = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Which drivers license do you have?: ");
            Console.WriteLine("|1| - A\n|2| - B\n|3| - C\n|4| - I have no drivers license");
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
                licenseType = (int)License.NoLicense;
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input. Try again.");
            }
        }
        return licenseType;
    }

    public int ChooseEducationToSeeker()
    {
        int educationType = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("What level of education do you have?: ");
            Console.WriteLine("|1| - Gymnasium\n|2| - Universitet\n|3| - Yrkeshögskola\n|4| - Folkhögskola\n|5| - I have no education");
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
                educationType = (int)Education.NoEducation;
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input. Try again.");
            }
        }
        return educationType;
    }

    public int ChooseLicenseToJob()
    {
        int licenseType = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose a  driver license requirement for the job: ");
            Console.WriteLine("|1| - A\n|2| - B\n|3| - C\n|4| - No Requirements");
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
                licenseType = (int)License.NoLicense;
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
            Console.Clear();
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
                educationType = (int)Education.NoEducation;
                break;
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
            Console.WriteLine("|1| - Login User\n|2| - Login Company");
            ConsoleKey inputKey = Console.ReadKey().Key;

            if (inputKey == ConsoleKey.D1) // Login User
            {
                Console.Clear();
                Console.Write("Please enter your email:");
                string email = Console.ReadLine();
                Console.Write("Please enter your password:");
                string password = Console.ReadLine();

                if (newSeeker.LoginJobSeeker(email, password) && email != "" && password != "" && email != " " && password != " ")
                {
                    Console.Clear();
                    bool SeekerMenu = true;
                    while (SeekerMenu == true)
                    {
                        Console.Clear();
                        Console.WriteLine("|1| - Apply for job\n|2| - Delete job application\n|3| - Delete Account\n|Q| - Logout");
                        ConsoleKey seekerMenuKey = Console.ReadKey().Key;

                        if (seekerMenuKey == ConsoleKey.D1) // ADD A SEEKER TO A JOB
                        {
                            Console.Clear();

                            SeekerDB seeker_job = new();
                            JobDB job_seeker = new();
                            List<int> jobIDs = new();

                            Console.WriteLine("Available jobs:\n");
                            foreach (var job in job_seeker.GetJobRequirements(SeekerLogic.loggedInSeekerId))
                            {
                                jobIDs.Add(job);
                            }
                            foreach (var job in seeker_job.GetJobNameAndID(jobIDs))
                            {
                                Console.WriteLine($"|ID|{job.Job_id} - {job.Job_title} in {job.Job_location}\nJob description: {job.Job_description}\n");
                            }

                            Console.WriteLine("\nEnter the ID of the job you want to apply for");

                            int SeekerApply;
                            bool success = int.TryParse(Console.ReadLine(), out SeekerApply);
                            if (jobIDs.Contains(SeekerApply) && success)
                            {
                                seeker_job.AddToSeeker_Job(SeekerLogic.loggedInSeekerId, SeekerApply);
                                Console.Clear();
                                Console.Write($"\nYou have applied for {SeekerApply}!\nPress any key to continue");
                                Console.ReadKey();
                            }
                            else if (!success)
                            {
                                //Go back to menu.
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("Specified ID does not exist.\nPress any key to return");
                                Console.ReadLine();
                            }

                        }

                        else if (seekerMenuKey == ConsoleKey.D2) // DELETE A SEEKER FROM A JOB
                        {
                            Console.Clear();
                            SeekerDB seeker_job = new();
                            List<Job> JobList = new();
                            List<int> IdList = new();

                            Console.Write("Your current applications :\n");
                            foreach (var job in seeker_job.GetSeekerApplyHistory(SeekerLogic.loggedInSeekerId))
                            {
                                JobList.Add(job);
                            }
                            foreach (var job in JobList)
                            {
                                Console.WriteLine($"|ID|{job.Job_id} - {job.Job_title} in {job.Job_location}");
                            }
                            foreach (var job in JobList)
                            {
                                IdList.Add(job.Job_id);
                            }

                            Console.WriteLine("\nEnter the ID of the job you want stop applying for: ");
                            int SeekerRemove = isNumbers(Console.ReadLine());

                            if (IdList.Contains(SeekerRemove))
                            {
                                Console.Clear();
                                Console.Write($"Are you sure you want to stop applying for {SeekerRemove}?\n|1| - Delete\n|2| - Go Back");
                                ConsoleKey confirmKey = Console.ReadKey().Key;

                                if (confirmKey == ConsoleKey.D1)
                                {
                                    Console.Clear();
                                    seeker_job.RemoveFromSeeker_Job(SeekerLogic.loggedInSeekerId, SeekerRemove);
                                    Console.Write($"You are no longer applying for {SeekerRemove}.\nPress any key to return");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("Specified ID does not exist.\nPress any key to return");
                                Console.ReadLine();
                            }
                        }

                        else if (seekerMenuKey == ConsoleKey.D3) // DELETE SEEKER
                        {
                            Console.Clear();
                            SeekerDB seeker_job = new();
                            Console.WriteLine("Are you sure you want to delete your account?");
                            Console.WriteLine("|1| - Delete\n|2| - Go Back\n");
                            ConsoleKey choice = Console.ReadKey().Key;
                            if (choice == ConsoleKey.D1)
                            {
                                Console.Clear();
                                seeker_job.DeleteSeeker(SeekerLogic.loggedInSeekerId);
                                Console.WriteLine("Account is deleted.\nPress any key to go back to main menu");
                                Console.ReadLine();
                                Menu();
                            }
                        }
                        else if (seekerMenuKey == ConsoleKey.Q)
                        {
                            Menu();
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
            else if (inputKey == ConsoleKey.D2) // Login Company
            {
                Console.Clear();
                Console.Write("Please enter your email:");
                string email = Console.ReadLine().ToLower();
                Console.Write("Please enter your password:");
                string password = Console.ReadLine();
                if (newCompany.LoginCompany(email, password) && email != "" && password != "" && email != " " && password != " ")
                {
                    bool companyLoop = true;
                    while (companyLoop)
                    {
                        CompanyDB newCompanyDB = new();
                        Console.Clear();
                        Console.WriteLine("|1| - Register new job\n|2| - See all applicants\n|3| - See all your job ads\n|Q| - Logout");
                        ConsoleKey input = Console.ReadKey().Key;

                        if (input == ConsoleKey.D1)
                        {
                            Console.Clear();
                            Console.WriteLine("Register new job ad.");
                            RegisterNewJob();
                        }
                        else if (input == ConsoleKey.D2)
                        {
                            SeekerDB sDB = new();
                            Console.Clear();
                            Console.WriteLine("List of Applicants\n");
                            List<Seeker_job> seeker_job = newCompanyDB.GetSeekersThatApplyToCompany(CompanyLogic.loggedInCompanyId);
                            List<Seeker> listOfSeeker = sDB.SearchSeekerInDB();
                            List<Job> listOfCompanyJobs = newCompanyDB.ListCompanyJobs(CompanyLogic.loggedInCompanyId);
                            foreach (var jobId in seeker_job)
                            {
                                foreach (var seeker in listOfSeeker)
                                {
                                    foreach (var job in listOfCompanyJobs)
                                    {
                                        if (jobId.Seeker_id == seeker.Seeker_id && jobId.Job_id == job.Job_id)
                                        {
                                            Console.WriteLine($"{seeker.Seeker_name} have applied for job: {job.Job_title} |ID|{job.Job_id}.");
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("\nPress any button to continue.");
                            Console.ReadLine();
                        }
                        else if (input == ConsoleKey.D3)
                        {
                            Console.Clear();
                            Console.WriteLine("List of all job ads\n");
                            List<int> tempList = new();
                            foreach (var job in newCompanyDB.ListCompanyJobs(CompanyLogic.loggedInCompanyId))
                            {
                                Console.WriteLine(job.ToString());
                                tempList.Add(job.Job_id);
                            }
                            int jobId;
                            Console.Write("\nPress enter to continue or enter job ad id to delete: ");
                            bool success = int.TryParse(Console.ReadLine(), out jobId);
                            if (tempList.Contains(jobId) && success)
                            {
                                newCompanyDB.DeleteJobDB(CompanyLogic.loggedInCompanyId, jobId);
                                Console.Write("Delete successful.");
                                Console.ReadLine();
                            }
                            else if (!success)
                            {
                                //Go back to menu.
                            }
                            else
                            {
                                Console.Write("Delete was unsuccessful.\nPlease try again.");
                                Console.ReadLine();
                            }
                        }
                        else if (input == ConsoleKey.Q)
                        {
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please try again");
                        }
                    }
                }
                else
                {
                    Console.Write("Wrong email or password!\nPlease try again.");
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
    public string CheckIfNullOrWhiteSpace(string inputWord)
    {
        bool isEmpty = String.IsNullOrWhiteSpace(inputWord);
        bool success = true;
        while (success)
        {
            if (!isEmpty)
            {
                return inputWord;
            }
            else if (isEmpty)
            {
                Console.Write("Please try again: ");
                isEmpty = String.IsNullOrWhiteSpace(inputWord = Console.ReadLine());
            }
        }
        return inputWord;
    }
    public static int isNumbers(string input)
    {
        int number;
        while (true)
        {
            bool success = int.TryParse(input, out number);
            if (success)
            {
                break;
            }
            else
            {
                Console.WriteLine("Must be a number. Try again: ");
                input = Console.ReadLine();
            }
        }
        return number;
    }
}