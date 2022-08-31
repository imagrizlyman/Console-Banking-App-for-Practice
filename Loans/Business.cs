using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBankAppNum2.Loans
{
    internal class Business : Loan
    {
        public Business(string loanTyp, string loanNme, double loanAmnt, double intRate, int loanTrm, double paymentamnt) : base(loanTyp, loanNme, loanAmnt, intRate, loanTrm, paymentamnt)
        {

        }
    }
}
