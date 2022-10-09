﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBankAppNum2.Loans
{
    public class Mortgage : Loan
    {
        private double interestRate;
        private double loanTerm;
        private double paymentAmount;

        public Mortgage(string loanTyp, string loanNme, double loanAmnt, double intRate, int loanTrm, double paymentamnt)
        {
            this.loanType = loanTyp;
            this.LoanName = loanNme;
            this.LoanOriginationAmount = loanAmnt;
            this.interestRate = intRate;
            this.loanTerm = loanTrm;
            this.paymentAmount = paymentamnt;
        }
        public string LoanType { get; set; }
        public string LoanName { get; set; }
        public double LoanOriginationAmount { get; set; }
        public double InterestRate
        {
            get { return interestRate; }
        }
        public double LoanTerm
        {
            get { return loanTerm; }
        }
        public double PaymentAmount
        {
            get { return paymentAmount; }
        }
        public static void MortgageLoanInformationCollection()
        {
            Console.WriteLine("Please enter the dollar amount you are requesting for your Mortgage loan:");
            string loanOrigAmountString = Console.ReadLine();
            if (double.TryParse(loanOrigAmountString, out double result))
            {
                loanOrigAmount = result;
            }
            else
            {
                Console.WriteLine("Invalid entry, please enter numbers only..");
                MortgageLoanInformationCollection();
            }
            Console.WriteLine("Please enter the amount of whole months you would like for your loan term:");
            string loanTrmString = Console.ReadLine();
            if (int.TryParse(loanTrmString, out int result1))
            {
                loanTrm = result1;
            }
            else
            {
                Console.WriteLine("Invalid entry, please enter numbers only..");
                MortgageLoanInformationCollection();
            }
            Console.WriteLine("Please enter your gross annual income:");
            string annualIncomeString = Console.ReadLine();
            if (double.TryParse(annualIncomeString, out double result2))
            {
                annualIncome = result2;
            }
            else
            {
                Console.WriteLine("Invalid entry, please enter numbers only..");
                MortgageLoanInformationCollection();
            }
            Console.WriteLine("Please enter your Credit Score:");
            string creditScoreString = Console.ReadLine();
            if (int.TryParse(creditScoreString, out int result3))
            {
                creditScore = result3;
            }
            else
            {
                Console.WriteLine("Invalid entry, please enter numbers only..");
                MortgageLoanInformationCollection();
            }
        }
    }
}
