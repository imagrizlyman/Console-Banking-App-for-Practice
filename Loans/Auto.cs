using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBankAppNum2.Loans
{
    public class Auto : Loan
    {
       
        public Auto(string loanTyp, string loanNme, double loanAmnt, double intRate, int loanTrm, double paymentamnt) : base(loanTyp, loanNme, loanAmnt, intRate, loanTrm, paymentamnt)
        {

        }

        public static void AutoLoanInformationCollection()
        {
            Console.WriteLine("Please enter the dollar amount you are requesting for your Auto loan:");
            loanOrigAmount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the amount of whole months you would like for your loan term:");
            loanTrm = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Please enter your gross annual income:");
            annualIncome = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter your Credit Score:");
            creditScore = Convert.ToInt16(Console.ReadLine());
        }

        public static bool AutoLoanApplication()
        {
            double monthlyIncome = annualIncome / 12;
            if (monthlyIncome < 1500 || creditScore < 600)
            {
                return false;
            }
            
            
        }

        public static double MaxLoanAmountDetermination()
        {
            string loanWorthiness;

            if (creditScore >= 720)
            {
                loanWorthiness = "excellent";
                interestRate = .035;
            }
            else if (creditScore >= 640 && creditScore < 720)
            {
                loanWorthiness = "okay";
                interestRate = .047;
            }
            else
            {
                loanWorthiness = "bad";
                interestRate = .080;
            }
            
            switch (loanWorthiness)
            {
                case "excellent":
                    double maxLoanPreInterest = ((annualIncome / 12) * .30) * loanTrm;
                    double interestTotal = interestRate * maxLoanPreInterest;
                    return maxLoanPreInterest + interestTotal;
                    break;
            }
        }
    }
}
