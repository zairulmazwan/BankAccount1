using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class Transaction
    {
        public int accountNumber { get; set; }
        public double deposit { get; set; }
        public double withdrawal { get; set; }

        /*
        public void Deposit(int acc, double deposit)
        {
            this.accountNumber = accountNumber;
            this.deposit = deposit;ce\Repos
        }

        public void Withdrawal(int acc,double wdrawal)
        {
            this.accountNumber = accountNumber;
            this.withdrawal = wdrawal;
        }

    */
    }
}
