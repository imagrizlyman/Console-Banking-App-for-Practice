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
            if (monthlyIncome < 1500 || creditScore < 600 || loanOrigAmount > maxLoanAmount)
            {
                return false;
            }
            return true;
            
        }

        public static void MaxLoanAmountDetermination()
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
                    maxLoanAmount = maxLoanPreInterest + interestTotal;
                    break;
                case "okay":
                    double maxLoanPreInterest1 = ((annualIncome / 12) * .20) * loanTrm;
                    double interestTotal1 = ((annualIncome / 12) * .20) * loanTrm;
                    maxLoanAmount = maxLoanPreInterest1 + interestTotal1; 
                    break;
                default:
                    double maxLoanPreInterest2 = ((annualIncome / 12) * .15) * loanTrm;
                    double interestTotal2 = ((annualIncome / 12) * .15) * loanTrm;
                    maxLoanAmount = interestTotal2 + maxLoanPreInterest2;
                    break;
            }
        }
        public static void AutoLoanEstablishment()
        {
            if (Auto.AutoLoanApplication())
            {
                Console.WriteLine("You are approved for the new Auto Loan!");
                minimumPayment = (loanOrigAmount / loanTrm) + (interestRate * loanOrigAmount) / loanTrm;
                Console.WriteLine($"Your payment for this loan will be in the amount of {minimumPayment}, do you wish to continue with this loan? ");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes")
                {
                    Console.WriteLine("What will you name this loan?");
                    loanName = Console.ReadLine();
                    Auto newAutoLoan = new Auto("Auto", loanName, loanOrigAmount, interestRate, loanTrm, minimumPayment);
                    CustomerAccounts.accountLoggedIn.LoanList.Add(newAutoLoan);
                }
                else
                {
                    CustomerAccounts.ExistingAccountMenu();
                }

            }
            else
            {
                Console.WriteLine("We do apologize, but we are unable to approve your application for an Auto loan at this time.");
                Console.WriteLine("Feel free to apply again at a later time, Thank you.");
                CustomerAccounts.ExistingAccountMenu();
            }
        }
    }
}
