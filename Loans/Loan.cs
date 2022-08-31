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

        public static void LoanApplication()
        {
            bool loanDecision;
            Console.WriteLine("Please Enter the type of loan you are seeking today. (Auto, Mortgage, Business, Personal etc.)");
            string loanTyp = Console.ReadLine().ToLower();

        }

        /* FOR MAKING LOAN PAYMENTS, MAKE IT TO WHERE YOU HAVE TO PAY FROM YOUR BALANCE
            ALSO MAKE THE PAYMENT BE A MINIMUM PAYMENT AMOUNT OR ABOVE*/
    }
}
