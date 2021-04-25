using System;
using System.Collections.Generic;
using System.Text;
using BankManagement.Business;
namespace BankManagement.DataLayer
{
    public class Customer
    {
        public string PanNumber { get; set; }    //store pan id
        public List<BankAccount> Accounts;  //store all account references
        /// <summary>
        /// Creates customer with given pan Number
        /// </summary>
        /// <param name="panNumber">Pan Nubmer</param>
        public Customer(string panNumber)
        {
            PanNumber = panNumber;
            Accounts = new List<BankAccount>();
        }
    }
}
