using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBankAppNum2.Loans
{


    public class Loan
    {
        public string loanType;
        public string loanName;
        public double loanOriginationAmount;
        public double interestRate;
        public int loanTerm;
        public double loanBalance;
        public double minimumPayment;
        public static double loanOrigAmount;
        public static int loanTrm;
        public static double annualIncome;
        public static int creditScore;

        
        public Loan(string loanTyp, string loanNme, double loanAmnt, double intRate, int loanTrm, double paymentamnt)
        {
            loanType = loanTyp;
            loanOriginationAmount = loanAmnt;
            interestRate = intRate;
            loanTerm = loanTrm;
            loanName = loanNme;
            minimumPayment = paymentamnt;
        }
        public double LoanBalance { get { return loanBalance; } set { loanBalance = value; } }
        public string LoanName { get; set; }
        public double LoanOriginationAmount { get { return loanOriginationAmount; } set { } }
        public double InterestRate { get { return interestRate; } set { } }
        public double MinimumPayment { get { return minimumPayment; } set { } }
        public int LoanTerm { get { return loanTerm; } set { } }

        public static string LoanTypeDetermination()
        {
            Console.WriteLine("Please Enter the type of loan you are seeking today. (Auto, Mortgage, Business, or Personal)");
            return Console.ReadLine().ToLower();
        }

        public static bool LoanApplication()
        {
            Console.WriteLine("Thank you for considering Hacker Bank for your loan.");
            string loanType = LoanTypeDetermination();
            LoanInformationCollection();
            switch (loanType)
            {
                case "auto":
                    break;
                case "mortgage":
                    break;
                case "business":
                    break;
                case "personal":
                    break;
                default:
                    Console.WriteLine("Invalid Loan type selection, Please try again.");
                    LoanTypeDetermination();
                    LoanApplication();
                    break;
            }
            return true;
        }

        public static void LoanInformationCollection()
        {
            Console.WriteLine("Please enter the dollar amount you are requesting for your loan:");
            loanOrigAmount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the amount of months you would like for your loan term:");
            loanTrm = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Please enter your gross annual income:");
            annualIncome = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter your Credit Score:");
            creditScore = Convert.ToInt16(Console.ReadLine());
        }
        


        /* FOR MAKING LOAN PAYMENTS, MAKE IT TO WHERE YOU HAVE TO PAY FROM YOUR BALANCE
            ALSO MAKE THE PAYMENT BE A MINIMUM PAYMENT AMOUNT OR ABOVE*/
    }
}
