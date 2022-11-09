using System.Collections;
namespace BasicBankAppNum2
{
    internal class Program
    {
        public static string userChoice;
        public static bool appIsRunning = true;
        
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            BankIntro();
            while (appIsRunning)
            {
                MainMenuSelection();
            }
            
        }

        public static void BankIntro()
        {
            Console.WriteLine("*******************************************************");
            Console.WriteLine("**            Welcome to Hackers Bank            **");
            Console.WriteLine("*******************************************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**What Can we help you with today?**");
            Console.WriteLine("*Enter the number for your selection.*");
            Console.WriteLine("1. Set up a new account");
            Console.WriteLine("2. Log into existing account");
            Console.WriteLine("3. Exit");
            userChoice = Console.ReadLine();

        }
       
        public static void MainMenuSelection()
        {
            switch (userChoice)
            {
                case "1":
                    CustomerAccounts.NewAccountCreation();
                    NewChoice();
                    break;
                case "2":
                    CustomerAccounts.LoggingIn();
                    NewChoice();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Please enter a valid selection.");
                    userChoice = Console.ReadLine();
                    MainMenuSelection();
                    break;
            }
            

        }

        private static void NewChoice()
        {
            Console.WriteLine("Would you like to complete another transaction?");
            string yesOrNo = Console.ReadLine();
            if (yesOrNo == "yes")
            {
                Console.WriteLine("**What Can we help you with today?**");
                Console.WriteLine("*Enter the number for your selection.*");
                Console.WriteLine("1. Set up a new account");
                Console.WriteLine("2. Log into existing account");
                Console.WriteLine("3. Exit");
                userChoice = Console.ReadLine();
                MainMenuSelection();
            }
            else if (yesOrNo == "no")
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for banking with us today!");
                appIsRunning = false;
            }
            else
            {
                Console.WriteLine("Please enter a valid choice, (yes or no).");
                NewChoice();
            }
        }

        
    }

}