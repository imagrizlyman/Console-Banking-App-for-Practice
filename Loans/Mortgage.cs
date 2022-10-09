using System;
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
    }
}
