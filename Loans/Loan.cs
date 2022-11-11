using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BasicBankAppNum2.Loans
{


    public class Loan
    {
        internal string loanType;
        internal static string loanName;
        internal double loanOriginationAmount;
        internal static double interestRate;
        internal int loanTerm;
        internal double loanBalance = loanOrigAmount;
        internal static double minimumPayment;
        internal static double loanOrigAmount;
        internal static int loanTrm;
        internal static double annualIncome;
        internal static int creditScore;
        internal static string loanTyp;
        internal static bool loanDecision;
        internal static double maxLoanAmount;
        
        public Loan(string loanTyp, string loanNme, double loanAmnt, double intRate, int loanTrm, double paymentamnt)
        {
            this.loanType = loanTyp;
            this.LoanOriginationAmount = loanAmnt;
            interestRate = intRate;
            this.LoanTerm = loanTrm;
            this.LoanName = loanNme;
            this.MinimumPayment = paymentamnt;
        }
        public Loan()
        {

        }
        public double LoanBalance { get { return loanBalance; } set { loanBalance = value; } }
        public string LoanName { get; set; }
        public double LoanOriginationAmount { get { return loanOriginationAmount; } set { } }
        public double InterestRate { get { return interestRate; } set { } }
        public double MinimumPayment { get { return minimumPayment; } set { } }
        public int LoanTerm { get { return loanTerm; } set { } }

        public static void LoanTypeDetermination()
        {
            Console.WriteLine("Please Enter the type of loan you are seeking today. (Auto)");
            Console.WriteLine("We do apologize but currently we are only offering auto loans.. Please just enter auto if that is what you would like..");
            loanTyp = Console.ReadLine().ToLower();
            if (loanTyp != "auto")
            {
                LoanTypeDetermination();
            }
        }

        public static bool LoanApplication()
        {
            Console.WriteLine("Thank you for considering Hacker Bank for your loan.");
            LoanTypeDetermination();
            switch (loanTyp)
            {
                case "auto":
                    Auto.AutoLoanInformationCollection();
                    Auto.MaxLoanAmountDetermination();
                    Auto.AutoLoanEstablishment();
                    CustomerAccounts.ExistingAccountMenu();
                    break;
                case "mortgage":

                    CustomerAccounts.ExistingAccountMenu();
                    break;
                case "business":

                    CustomerAccounts.ExistingAccountMenu();
                    break;
                case "personal":

                    CustomerAccounts.ExistingAccountMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Loan type selection, Please try again.");
                    LoanApplication();
                    break;
            }
            return true;
        }
        public static void CheckExistingLoans()
        {
            int loanSelection;
            if (CustomerAccounts.accountLoggedIn.LoanList.Count > 0)
            {
                foreach (Loan loan in CustomerAccounts.accountLoggedIn.LoanList)
                {
                    Console.WriteLine(loan.LoanName);
                }
                Console.WriteLine("Would you like to manage any of these loans?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes")
                {
                    Console.WriteLine("Please select the loan you would like to manage: ");
                    int count = 1;
                    foreach (Loan loan in CustomerAccounts.accountLoggedIn.LoanList)
                    {
                        Console.WriteLine($"{count}: {loan.LoanName}");
                        count++;
                    }
                returnPoint:
                    Console.WriteLine("Please enter the corresponding number for your selection: ");
                    string loanSelectionString = Console.ReadLine();
                    if (int.TryParse(loanSelectionString, out loanSelection))
                    {
                        loanSelection = loanSelection;
                    }
                    else
                    {
                        CheckExistingLoans();
                        goto returnPoint;
                    }
                    Console.WriteLine($"The loan you selected was {CustomerAccounts.accountLoggedIn.LoanList[loanSelection - 1].LoanName}");
                    CustomerAccounts.selectedLoan = CustomerAccounts.accountLoggedIn.LoanList[loanSelection - 1];
                    ManageSelectedLoan();

                }
                else
                {
                    CustomerAccounts.ExistingAccountMenu();
                }
            }
            else
            {
                Console.WriteLine("It appears that currently you do not hold any active loans with us.");
                Console.WriteLine("Feel free to apply for a loan!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
        public static void ManageSelectedLoan()
        {
            SelectedLoanMenu();
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    Console.WriteLine($"Your current balance on the loan: {CustomerAccounts.selectedLoan.LoanName} is ${CustomerAccounts.selectedLoan.LoanBalance}");
                    Console.WriteLine("Submit any key to return to the Loan Menu..");
                    string continueChoice = Console.ReadLine();
                    if (continueChoice != null)
                    {
                        ManageSelectedLoan();
                    }
                    break;
                case "2":
                    MakeLoanPayment();
                    Console.WriteLine("Submit any key to return to the Loan Menu..");
                    continueChoice = Console.ReadLine();
                    if (continueChoice != null)
                    {
                        ManageSelectedLoan();
                    }
                    break;
                case "3":
                    Console.WriteLine($"Your current interest rate is %{CustomerAccounts.selectedLoan.InterestRate}");
                    Console.WriteLine("Submit any key to return to the Loan Menu..");
                    continueChoice = Console.ReadLine();
                    if (continueChoice != null)
                    {
                        ManageSelectedLoan();
                    }
                    break;
                case "4":
                    CustomerAccounts.ExistingAccountMenu();
                    break;
            }
        }
        public static void SelectedLoanMenu()
        {
            Console.WriteLine("How can we help you with this loan?");
            Console.WriteLine("1. Check current Loan Balance");
            Console.WriteLine("2. Make a Payment on your Loan");
            Console.WriteLine("3. Check current interest rate");
            Console.WriteLine("4. Return to Account Menu");
        }
        public static void MakeLoanPayment()
        {
            Console.WriteLine($"Your minimum payment for {CustomerAccounts.selectedLoan.LoanName} is ${CustomerAccounts.selectedLoan.MinimumPayment}");
            Console.WriteLine();
            Console.WriteLine("Would you like to make the minimum payment or a custom amount? (Enter 'minimum' to make the minimum, or 'custom' for a different amount): ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "minimum")
            {
                if (CustomerAccounts.accountLoggedIn.Balance >= CustomerAccounts.selectedLoan.MinimumPayment)
                {
                    CustomerAccounts.selectedLoan.LoanBalance -= CustomerAccounts.selectedLoan.MinimumPayment;
                    CustomerAccounts.accountLoggedIn.Balance -= CustomerAccounts.selectedLoan.MinimumPayment;
                    Console.WriteLine($"Your payment of {CustomerAccounts.selectedLoan.MinimumPayment} was applied succesfully.");
                    Console.WriteLine($"Your new loan balance is now {CustomerAccounts.selectedLoan.LoanBalance}");
                    Console.WriteLine("Submit any key to return to the Loan Menu..");
                    string continueChoice = Console.ReadLine();
                    if (continueChoice != null)
                    {
                        ManageSelectedLoan();
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("it appears you do not have enough funds in your bank account to make the minimum payment. Please add more funds to your account and try again..");
                    ManageSelectedLoan();
                }
            }
            else if (choice == "custom")
            {
                Console.WriteLine($"Please enter the custom amount you would like to pay today, Please remember it would need to greater than or equal to your minimum payment amount of {CustomerAccounts.selectedLoan.MinimumPayment}");
                string customPaymentString = Console.ReadLine();
                if (double.TryParse(customPaymentString, out double result))
                {
                    double paymentAmount = result;
                    if (CustomerAccounts.accountLoggedIn.Balance >= paymentAmount && paymentAmount >= CustomerAccounts.selectedLoan.MinimumPayment)
                    {
                        CustomerAccounts.selectedLoan.LoanBalance -= paymentAmount;
                        CustomerAccounts.accountLoggedIn.Balance -= paymentAmount;
                        Console.WriteLine($"Your payment of {paymentAmount} was applied succesfully.");
                        Console.WriteLine($"Your new loan balance is now {CustomerAccounts.selectedLoan.LoanBalance}");
                        Console.WriteLine("Submit any key to return to the Loan Menu..");
                        string continueChoice = Console.ReadLine();
                        if (continueChoice != null)
                        {
                            ManageSelectedLoan();
                        }
                    }
                    else if (CustomerAccounts.accountLoggedIn.Balance < paymentAmount)
                    {
                        Console.WriteLine("it appears you do not have enough funds in your account to make this payment, please add more funds and try again..");
                        ManageSelectedLoan();
                    }
                    else
                    {
                        Console.WriteLine($"Your custom payment must be at least ${CustomerAccounts.selectedLoan.MinimumPayment}");
                        ManageSelectedLoan();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid entry, please try again..");
                    MakeLoanPayment();
                }

            }
            else
            {
                Console.WriteLine("Invalid entry, try again..");
                MakeLoanPayment();
            }
        }
        
        
        

        

        


        
    }
}
