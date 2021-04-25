using System;
using System.Collections.Generic;
using System.Text;
using BankManagement.DataLayer;
using BankManagement.Business;

namespace BankManagement.Controller
{
    using BankManagement.XmlDatabase;
    using Utility;
    public class AccountControl
    {
        UserInput InputTaker;//Userd to take input from user
        public AccountControl()
        {
            InputTaker = new UserInput();
        }
         public void AccountControler(BankAccount account,Branch branchName)
        {
            Console.WriteLine(Constants.AccountNumberDisplay+account.AccountNumber);
            Console.WriteLine(Constants.BranchIdDisplay + branchName.BranchId);
            Console.WriteLine(Constants.AccountDisplay);
            try
            {
                int UserOption = InputTaker.GetIntInput(1,6);
                Console.Clear();
                switch (UserOption)
                {
                    case 1:
                        Console.WriteLine(Constants.BalanceDisplay + account.CurrentBalance);//Diplays Current Balance
                        AccountControler(account,branchName);
                        break;
                    case 2:
                        Deposit(account, branchName);//Deposits User Entered Amount into the Account
                        break;
                    case 3:
                        Withdraw(account,branchName);//Withdraws User Entered Amount From the Account
                        break;
                    case 4:
                        DisplayStatement(account.GetMinStatement());  //Gets The last 10 Transaction Histroy
                        AccountControler(account,branchName);
                        break;
                    case 5:
                        DisplayStatement(account.GetTransactionHistory());//Gets all the transaction History Available
                        AccountControler(account, branchName);
                        break;
                    case 6:
                        break;
                    default:
                        AccountControler(account,branchName);   //Loops the Application to display opitons again after a action is complete
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Takes Input Amount and adds to account current Balance
        /// </summary>
        /// <param name="acccount">Account Instance</param>
        /// <param name="branchName">Branch Instance</param>
        private void Deposit(BankAccount acccount, Branch branchName)
        {
            Console.WriteLine(Constants.EnterDepositAmount);
            Transaction NewTransaction = acccount.Deposit(InputTaker.GetDoubleInput(0));    //Deposits amount into account
            XmlStore Store = new XmlStore();
            Store.SaveTransaction(NewTransaction, acccount, branchName);                    //Savse Transaction to database
            Console.WriteLine(Constants.Deposited);                                         //Transaction complete message
            AccountControler(acccount, branchName);                                         //calls Account controls
        }
        /// <summary>
        /// Takes Input Amount and deducts form account current Balance
        /// </summary>
        /// <param name="acccount">Account Instance</param>
        /// <param name="branchName">Branch Instance</param>
        private void Withdraw(BankAccount Acccount, Branch BranchName)
        {
            Transaction NewTransaction;
            Console.WriteLine(Constants.EnterWithdrawAmount);
            NewTransaction = Acccount.Withdraw(InputTaker.GetDoubleInput(0));               //Withdraws from the account
            XmlStore Store = new XmlStore();
            Store.SaveTransaction(NewTransaction, Acccount, BranchName);                    //Saves Transaction to database
            Console.WriteLine(Constants.Withdrawed);                                        //Transaction complete message
            AccountControler(Acccount, BranchName);                                         //calls Account controls again
        }
        /// <summary>
        /// Displays All transactoins Passed as parameter
        /// </summary>
        /// <param name="Transactions">List of Transactions to display</param>
        private void DisplayStatement(List<Transaction> Transactions)
        {
            foreach (Transaction transaction in Transactions)
            {
                Console.WriteLine(Constants.Dashes);
                Console.WriteLine(Constants.TransactionIdDisplay + transaction.TransactionId);
                Console.WriteLine(Constants.AmountDisplay + transaction.Amount);
                Console.WriteLine(Constants.TypeDiplay + transaction.Type);
                Console.WriteLine(Constants.Dashes);
            }
        }

        

    }
}
