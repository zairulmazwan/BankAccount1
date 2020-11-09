using System;
using System.Collections.Generic;

namespace BankAccount
{
    class Program
    {
        static List<BankAccount> AccountRecords = new List<BankAccount>();
        static List<Transaction> TransactionRecords = new List<Transaction>();
        static bool login = true;
        static void Main(string[] args)
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("\t\tWelcome to Bank ABC");
            Console.WriteLine("=========================================================");


            while(login)
            {
                gettingMenu();
                string val = Console.ReadLine();
                int menu = Convert.ToInt32(val);

                if (menu == 1)
                {
                    Menu_1();
                   
                }
                else if (menu == 2)
                {
                    Menu_2();
                    
                }
                else if (menu == 3)
                {
                    Menu_3();
                   
                }
                else if (menu == 4)
                {
                    Menu_4();

                }
                else if (menu == 5)
                {
                    Menu_5();
                   
                }
                else if (menu == 6)
                {
                    Menu_6();
                    
                }
                else if (menu == 7)
                {
                    Menu_7();

                }
                else
                {
                    Console.WriteLine("Wrong menu has been selected");
                }
            }


            Console.WriteLine("You have exited from Bank Account system");
            Console.ReadLine();
        }


       public static void gettingMenu ()
        {
            Console.WriteLine("::Main Menu::\n");
            Console.WriteLine("Select a menu\n");
            Console.WriteLine("1 : Account Opening\n2 : Deposit\n3 : Withdrawal\n4 : View Account Balance\n5 : View Account Transactions\n6 : List of Account\n7 : Exit\n");
            Console.WriteLine("Your choice : ");
         
        }

        public static void Menu_1()
        {
            Console.WriteLine("\n:: Account Creation ::\n");
            Console.WriteLine("Input customer first name :");
            string fName = Console.ReadLine();

            Console.WriteLine("Input customer last name :");
            string lName = Console.ReadLine();

            Console.WriteLine("Input initial deposit :");
            string depositString = Console.ReadLine();
            double deposit = Convert.ToDouble(depositString);

            BankAccount acc = new BankAccount(fName, lName, deposit);
            AccountRecords.Add(acc);

            Transaction newTrans = new Transaction();
            newTrans.accountNumber = acc.AccountNumber;
            newTrans.deposit = deposit;
            TransactionRecords.Add(newTrans);

            Console.WriteLine("\n\nAn account has been created!");
            Console.WriteLine("Account holder name : " + acc.FirstName + " " + acc.LastName);
            Console.WriteLine("Account number : " + acc.AccountNumber);
            Console.WriteLine("Initial deposit : " + acc.Balance+"\n\n");
           
        }


        public static void Menu_2()
        {
            //Console.WriteLine("Menu 2 is selected");
           
            Console.WriteLine("\n:: Deposit Money ::\n");

            int accNumberIndex = searchAccount();

            if (accNumberIndex == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Account number not found!");
            }
            else
            {
                Console.WriteLine("Input deposit amount :");
                string depositString = Console.ReadLine();
                double deposit = Convert.ToDouble(depositString);

                AccountRecords[accNumberIndex].Balance += deposit;
                Transaction newTrans = new Transaction();
                newTrans.accountNumber = AccountRecords[accNumberIndex].AccountNumber; //getting the account number at index "accNumberIndex"
                newTrans.deposit = deposit;
                TransactionRecords.Add(newTrans);

                Console.WriteLine("Current balance :" + AccountRecords[0].Balance);
            }

            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void Menu_3()
        {
            Console.WriteLine("\n:: Withdraw Money ::\n");

            int accNumberIndex = searchAccount();

            if (accNumberIndex!=-1)
            {
                Console.WriteLine("Input amount to withdraw:");
                string withdrawalString = Console.ReadLine();
                double withdrawal = Convert.ToDouble(withdrawalString);

                if (AccountRecords[accNumberIndex].Balance - withdrawal > 0)
                {
                    AccountRecords[accNumberIndex].Balance -= withdrawal;
                    Transaction newTrans = new Transaction();
                    newTrans.accountNumber = AccountRecords[accNumberIndex].AccountNumber; //getting the account number at index "accNumberIndex"
                    newTrans.withdrawal = (-withdrawal);
                    TransactionRecords.Add(newTrans);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You dont have a sufficient balance to withdraw");
                }
                Console.ForegroundColor = ConsoleColor.White;



                Console.WriteLine("Current balance after withdrawal :" + AccountRecords[0].Balance);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Account Number!\n\n");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void Menu_4()
        {
            Console.WriteLine("Input account for balance :");
            string accNum = Console.ReadLine();

            string fName=null;
            string lName=null;
            double bal=0.0;

            foreach(var acc in AccountRecords)
            {
                if (acc.AccountNumber == accNum)
                {
                    fName = acc.FirstName;
                    lName = acc.LastName;
                    bal = acc.Balance;
                    break;
                }

            }

            if (fName!=null)
            {
                Console.WriteLine("Account holder :" + fName + " " + lName);
                Console.WriteLine("Balance :" + bal+"\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Record not found!" + "\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Menu_5()
        {
            Console.WriteLine("\n:: View Transaction History ::\n");
            int accNumberIndex = searchAccount(); //search an account number and return the index

            if (accNumberIndex !=-1)
            {
                string accNumber = AccountRecords[accNumberIndex].AccountNumber;

                Console.WriteLine("Transaction History : \n");
                Console.WriteLine("Deposit\t\t\tWithdrawal");
                foreach (var record in TransactionRecords)
                {
                    if (record.accountNumber == accNumber)
                    {
                        Console.WriteLine(record.deposit + "\t\t\t" + record.withdrawal + "\n");
                    }
                }
                Console.WriteLine("Account Balance : " + AccountRecords[accNumberIndex].Balance + "\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Record not found!");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Menu_7()
        {
           
            login = false;

        }

        public static void Menu_6 ()
        {
            Console.WriteLine("\n:: Lis of Accounts ::\n");
            Console.WriteLine("Account Number\t\t\tAccount Holder\t\t\t\tBalance");

            foreach (var acc in AccountRecords)
            {
                Console.WriteLine(acc.AccountNumber + "\t\t\t\t" + acc.FirstName + " " + acc.LastName + "\t\t\t\t" + acc.Balance);
            }
        }

        public static int searchAccount () //returns the index of the account number
        {
            int index=-1;

            Console.WriteLine("Input account number :");
            string accNum = Console.ReadLine();
          
            for (int i = 0; i< AccountRecords.Count; i++)
            {
               if (AccountRecords[i].AccountNumber==accNum)
                {
                    index = i;
                }
            }
            return index;
        }
    }
}
