using BankManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagement.Business
{
    public class CurrentAccount : BankAccount
    {
        /// <summary>
        /// Constructor Initilizes minimum balance,interest rate and account id
        /// </summary>
        /// <param name="AccountNumber">Account Number</param>
        public CurrentAccount(int AccountNumber)
        {
            base.MinimumBalance = 20000;
            base.InterestRate = 0;
            base.AccountNumber = AccountNumber;
        }

        public override AccountType GetAccountType()
        {
            return AccountType.Current;
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
