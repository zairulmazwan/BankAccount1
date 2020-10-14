using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class BankAccount
    {

        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
     

        public BankAccount(string FName, string LName, double initDeposit)
        {
            this.FirstName = FName;
            this.LastName = LName;
            this.Balance = initDeposit;
            this.AccountNumber = GetAccountNumber();

        }

        public string GetAccountNumber ()
        {

            System.Random random = new System.Random();
            int AccNum= random.Next(10000,99999);
            string productCode = "55";

            productCode += Convert.ToString(AccNum);

            return productCode;
        }

    }
}
