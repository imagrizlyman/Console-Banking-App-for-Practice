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
        public static List<CustomerAccounts> accountList = new List<CustomerAccounts> { };
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
        public static List<Loan> loanList = new List<Loan> { }; 
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





        public static void Login()
        {
            foreach (CustomerAccounts account in accountList)
            {
                if (usernameEntry == account.UserName)
                {
                    CustomerAccounts accountToLog = account;
                    if (passwordEntry == accountToLog.Password)
                    {
                        accountLoggedIn = accountToLog;
                        loggedInSuccess = true;
                    }
                    else
                    {
                        loggedInSuccess = false;
                    }

                }
                else
                {
                    loggedInSuccess = false;
                }
            }

        }
        public static void ExistingAccountMenu()
        {
            Console.WriteLine("How can we help you with your account?");
            Console.WriteLine("1. Check existing balance");
            Console.WriteLine("2. Make a deposit");
            Console.WriteLine("3. Make a withdrawal");
            Console.WriteLine("4. Check your active loans");
            Console.WriteLine("5. Apply for a loan");
            Console.WriteLine("6. Log Out & Return to the Main Menu");
            Program.userChoice = Console.ReadLine();
            ExistingAccountSelection();

        }
        public static void ExistingAccountSelection()
        {
            switch (Program.userChoice)
            {
                case "1":
                    Console.WriteLine(accountLoggedIn.Balance.ToString());
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
                    Console.WriteLine(accountLoggedIn.LoanList.ToString());
                    break;
                case "5":
                    Loan.LoanApplication();
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

        private static void ExistingAccountDeposit()
        {
            Console.WriteLine("Please enter the amount you would like to deposit");
            string amountToDepositString = Console.ReadLine();
            double amountToDeposit = Convert.ToDouble(amountToDepositString);
            accountLoggedIn.Balance += amountToDeposit;
            Console.WriteLine($"Thank you for your deposit, your new balance is ${accountLoggedIn.Balance}.");
        }

        private static void ExistingAccountwithdrawal()
        {
            Console.WriteLine("Please enter the amount you would like to withdraw");
            string amountTowithdrawalString = Console.ReadLine();
            double amountTowithdrawal = Convert.ToDouble(amountTowithdrawalString);
            accountLoggedIn.Balance -= amountTowithdrawal;
            Console.WriteLine($"Your withdrawal has completed. Your new balance is ${accountLoggedIn.Balance}");
        }
        public static void LoggingIN()
        {
            Console.WriteLine("Please enter your Username");
            usernameEntry = Console.ReadLine();
            Console.WriteLine("Thank you, now please enter your password.");
            passwordEntry = Console.ReadLine();
            Login();
            if (loggedInSuccess)
            {
                //Console.WriteLine("You did it!");
                ExistingAccountMenu();
            }
            else
            {
                Console.WriteLine("Incorrect login credentials.");
                LoggingIN();
                //Console.WriteLine(CustomerAccounts.accountLoggedIn.FirstName);
            }
        }
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