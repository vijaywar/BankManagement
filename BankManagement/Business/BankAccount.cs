using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BankManagement.DataLayer;

namespace BankManagement.Business
{
    public abstract class BankAccount
    {
        public BankAccount()
        {
            Transactions = new List<Transaction>();
        }
        public long AccountNumber;  //account number
        public int MinimumBalance;  //minimum balance
        public Double CurrentBalance;   //current balance
        public float InterestRate;      //interest rate
        public List<Transaction> Transactions; //list of transactions of this account

        /// <summary>
        /// Takes amount as input and subtracts from current balance.
        /// </summary>
        /// <param name="amount">Amout withdrawed</param>
        public  Transaction Withdraw(Double amount) {
            CurrentBalance -= amount;
            Transaction NewTransaction = new Transaction(Transactions.Count+1,amount,Operation.Withdraw);
            Transactions.Add(NewTransaction);
            return NewTransaction;
        }
        /// <summary>
        /// Adds amount to the current balance
        /// </summary>
        /// <param name="amount">Amount deposited</param>
        public  Transaction Deposit(Double amount)
        {
            CurrentBalance += amount;
            Transaction NewTransaction = new Transaction(Transactions.Count + 1, amount, Operation.Deposit);
            Transactions.Add(NewTransaction);
            return NewTransaction;
        }
        /// <summary>
        /// Gets all transaction history
        /// </summary>
        /// <returns>List of transactions</returns>
        public  List<Transaction> GetTransactionHistory()
        {
            return Transactions;
        }
        /// <summary>
        /// Gets last 10 transaction history
        /// </summary>
        /// <returns>returns list of 10 transactions</returns>
        public  List<Transaction> GetMinStatement()
        {
            return Transactions.TakeLast(10).ToList();
        }
        /// <summary>
        /// returns Account type it can be Current or Savings
        /// </summary>
        /// <returns>Account Type Current /Savings</returns>
        public abstract AccountType GetAccountType();
        /// <summary>
        /// Returns Current Balance
        /// </summary>
        /// <returns>Current Balance of Double data type,</returns>
        public abstract double GetCurrentBalance();
        /// <summary>
        /// returns Interest rate of the account
        /// </summary>
        /// <returns>inteest rate of float data type</returns>
        public abstract float GetInterestRate();
        /// <summary>
        /// returns Minimum balance of the account to be required
        /// </summary>
        /// <returns>double amount </returns>
        public abstract double GetMinimumBalance();
    }
}
