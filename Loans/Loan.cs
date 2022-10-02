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
        private string loanType;
        private static string loanName;
        private double loanOriginationAmount;
        private double interestRate;
        private int loanTerm;
        private double loanBalance = loanOrigAmount;
        private static double minimumPayment;
        private static double loanOrigAmount;
        private static int loanTrm;
        private static double annualIncome;
        private static int creditScore;
        private static string loanTyp;
        private static bool loanDecision;
        private static double maxLoanAmount;
        
        public Loan(string loanTyp, string loanNme, double loanAmnt, double intRate, int loanTrm, double paymentamnt)
        {
            this.loanType = loanTyp;
            this.LoanOriginationAmount = loanAmnt;
            this.interestRate = intRate;
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
            if (loanTyp != "auto" || loanTyp != "mortgage" || loanTyp != "personal" || loanTyp != "business")
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
        public static void ManageSelectedLoan()
        {

        }

        


        /* FOR MAKING LOAN PAYMENTS, MAKE IT TO WHERE YOU HAVE TO PAY FROM YOUR BALANCE
            ALSO MAKE THE PAYMENT BE A MINIMUM PAYMENT AMOUNT OR ABOVE*/
    }
}
