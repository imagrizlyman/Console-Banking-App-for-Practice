using BasicBankAppNum2.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBankAppNum2
{


    public class CustomerAccounts
    {
        public static List<CustomerAccounts> accountList = new List<CustomerAccounts> ();
        public static CustomerAccounts? accountLoggedIn;
        string userName;
        string password;
        string firstName;
        string lastName;
        string dateOfBirth;
        double balance;
        static string usernameEntry;
        static string passwordEntry;
        public static bool loggedInSuccess;
        public static Loan selectedLoan;
        private List<Loan> loanList = new List<Loan>(); 
        public CustomerAccounts(string firstNme, string lastNme, string dob, string userNme, string pswrd)
        {
            firstName = firstNme;
            lastName = lastNme;
            dateOfBirth = dob;
            userName = userNme;
            password = pswrd;
        }
        public string FirstName { get { return firstName; } set { } }
        public string LastName { get { return lastName; } set { } }
        public string DateOfBirth { get { return dateOfBirth; } set { } }
        public string UserName { get { return userName; } set { } }
        public string Password { get { return password; } set { } }
        public double Balance { get { return balance; } set { balance = value; } }
        public List<Loan> LoanList { get { return loanList; } set { loanList = value; } }

        

        //this is the extensive method used for logging into an existing account
        public static void LoggingIn()
        {
            Console.WriteLine("Please enter your Username");
            usernameEntry = Console.ReadLine();
            if (accountList.Count > 0)
            {
                foreach (CustomerAccounts account in accountList)
                {
                    //bool accountNotFound = false;
                    if (usernameEntry == account.UserName)
                    {
                        //accountNotFound = true;
                        CustomerAccounts accountToLog = account;
                        Console.WriteLine("Thank you, now please enter your password.");
                        passwordEntry = Console.ReadLine();
                        if (passwordEntry == accountToLog.Password)
                        {
                            accountLoggedIn = accountToLog;
                            ExistingAccountMenu();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Password..");
                            Console.WriteLine("Press any key to continue..");
                            Console.ReadLine();
                            LoggingIn();
                        }
                    }
                    
                }

                Console.WriteLine("We do not have an account by that username..");
                Console.WriteLine();
                Console.WriteLine("Would you like to try again? (yes or no)");
                string decision = Console.ReadLine();
                if (decision.ToLower() == "yes")
                {
                    LoggingIn();
                }
                else
                {
                    Program.BankIntro();
                    Program.MainMenuSelection();
                }
            }
            else
            {
                Console.WriteLine("We do not have an account by that username..");
                Console.WriteLine();
                Console.WriteLine("Would you like to try again? (yes or no)");
                string decision2 = Console.ReadLine();
                if (decision2.ToLower() == "yes")
                {
                    LoggingIn();
                }
                else
                {
                    Program.BankIntro();
                    Program.MainMenuSelection();
                }
            }
        }

        //This is the menu presented when logged in
        public static void ExistingAccountMenu()
        {
            Console.WriteLine("How can we help you with your account?");
            Console.WriteLine("1. Check existing balance");
            Console.WriteLine("2. Make a deposit");
            Console.WriteLine("3. Make a withdrawal");
            Console.WriteLine("4. Check your active loans");
            Console.WriteLine("5. Apply for a loan");
            Console.WriteLine("6. Log Out & Return to the Main Menu");
            Program.userChoice = Console.ReadLine() ?? string.Empty;
            ExistingAccountSelection();

        }
        //this is where the users selection is put into play from the existing account menu
        public static void ExistingAccountSelection()
        {
            switch (Program.userChoice)
            {
                case "1":
                    Console.WriteLine($"Your current Balance is ${accountLoggedIn.Balance.ToString()}");
                    Console.WriteLine("Submit any key to continue..");
                    string continueChoice = Console.ReadLine();
                    ExistingAccountMenu();
                    break;
                case "2":
                    ExistingAccountDeposit();
                    ExistingAccountMenu();
                    break;
                case "3":
                    ExistingAccountwithdrawal();
                    ExistingAccountMenu();
                    break;
                case "4":
                    Loan.CheckExistingLoans();
                    ExistingAccountMenu();
                    break;
                case "5":
                    Loan.LoanApplication();
                    ExistingAccountMenu();
                    break;
                case "6":
                    Program.BankIntro();
                    Program.MainMenuSelection();
                    break;
                default:
                    Console.WriteLine("Please enter a valid selection.");
                    Program.userChoice = Console.ReadLine();
                    ExistingAccountSelection();
                    break;
            }
        }
        //This is the method for making a deposit
        private static void ExistingAccountDeposit()
        {
            Console.WriteLine("Please enter the amount you would like to deposit");
            string amountToDepositString = Console.ReadLine();
            if (double.TryParse(amountToDepositString, out double result))
            {
                double amountToDeposit = result;
                accountLoggedIn.Balance += amountToDeposit;
            }
            else
            {
                Console.WriteLine("Invalid entry, please enter numbers only..");
                ExistingAccountDeposit();
            }
            Console.WriteLine($"Thank you for your deposit, your new balance is ${accountLoggedIn.Balance}.");
            Console.WriteLine("Submit any key to continue..");
            string continueChoice = Console.ReadLine();
        }
        //this is the method for making a withdrawl
        private static void ExistingAccountwithdrawal()
        {
            Console.WriteLine("Please enter the amount you would like to withdraw");
            string amountTowithdrawalString = Console.ReadLine();
            if (double.TryParse (amountTowithdrawalString, out double result))
            {
                double amountToWithdrawal = result;
                accountLoggedIn.Balance -= amountToWithdrawal;
            }
            else
            {
                Console.WriteLine("Invalid entry, please enter numbers only..");
                ExistingAccountwithdrawal();
            }
            Console.WriteLine($"Your withdrawal has completed. Your new balance is ${accountLoggedIn.Balance}");
            Console.WriteLine("Submit any key to continue..");
            string continueChoice = Console.ReadLine();
            
        }
        //This is the method for creating a new account
        public static void NewAccountCreation()
        {
            Console.WriteLine("Great!, Lets gather the information we need to establish your new account with us.");
            Console.WriteLine("Firstly, Can you provide your first name?");
            string fN = Console.ReadLine();
            Console.WriteLine("Thanks! Now provide your last name.");
            string lN = Console.ReadLine();
            Console.WriteLine("Great, enter your DOB.");
            string dob = Console.ReadLine();
            Console.WriteLine("Now enter the username you will use to log in.");
            string uN = Console.ReadLine();
            Console.WriteLine("Finally just enter the password you will use to log in.");
            string pW = Console.ReadLine();
            CustomerAccounts newAccount = new CustomerAccounts(fN, lN, dob, uN, pW);
            accountList.Add(newAccount);
        }
        
        
        
    }
}