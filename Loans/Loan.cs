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
        public string loanType;
        public static string loanName;
        public double loanOriginationAmount;
        public static double interestRate;
        public int loanTerm;
        public double loanBalance = loanOrigAmount;
        public static double minimumPayment;
        public static double loanOrigAmount;
        public static int loanTrm;
        public static double annualIncome;
        public static int creditScore;
        public static string loanTyp;
        public static bool loanDecision;
        public static double maxLoanAmount;
        
        public Loan(string loanTyp, string loanNme, double loanAmnt, double intRate, int loanTrm, double paymentamnt)
        {
            this.loanType = loanTyp;
            this.LoanOriginationAmount = loanAmnt;
            interestRate = intRate;
            this.LoanTerm = loanTrm;
            this.LoanName = loanNme;
            this.MinimumPayment = paymentamnt;
        }
        public double LoanBalance { get { return loanBalance; } set { loanBalance = value; } }
        public string LoanName { get; set; }
        public double LoanOriginationAmount { get { return loanOriginationAmount; } set { } }
        public double InterestRate { get { return interestRate; } set { } }
        public double MinimumPayment { get { return minimumPayment; } set { } }
        public int LoanTerm { get { return loanTerm; } set { } }

        public static void LoanTypeDetermination()
        {
            Console.WriteLine("Please Enter the type of loan you are seeking today. (Auto, Mortgage, Business, or Personal)");
            loanTyp = Console.ReadLine().ToLower();
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

        


        /* FOR MAKING LOAN PAYMENTS, MAKE IT TO WHERE YOU HAVE TO PAY FROM YOUR BALANCE
            ALSO MAKE THE PAYMENT BE A MINIMUM PAYMENT AMOUNT OR ABOVE*/
    }
}
