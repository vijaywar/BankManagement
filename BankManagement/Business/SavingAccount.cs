using System;
using System.Collections.Generic;
using System.Text;
using BankManagement.DataLayer;
namespace BankManagement.Business
{
    public class SavingAccount : BankAccount
    {
       public override AccountType GetAccountType()
        {
            return AccountType.Saving;
        }
        /// <summary>
        /// Initilizes minimum balance,interest rate and account number.
        /// </summary>
        /// <param name="AccountNumber">Account Number</param>
        public SavingAccount(int AccountNumber)
        {
            base.MinimumBalance = 10000;
            base.InterestRate = 4.5f;
            base.AccountNumber = AccountNumber;
        }

        /// <summary>
        /// Returns Current Balance
        /// </summary>
        /// <returns>Current Balance of Double data type,</returns>
        public override double GetCurrentBalance()
        {
            return base.CurrentBalance;
        }
        /// <summary>
        /// returns Interest rate of the account
        /// </summary>
        /// <returns>inteest rate of float data type</returns>
        public override float GetInterestRate()
        {
            return base.InterestRate;
        }
        /// <summary>
        /// returns Minimum balance of the account to be required
        /// </summary>
        /// <returns>double amount </returns>
        public override double GetMinimumBalance()
        {
            return base.MinimumBalance;
        }

    }
}
