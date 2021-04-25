using System;
using System.Collections.Generic;
using System.Text;
using BankManagement.DataLayer;
using System.Linq;
namespace BankManagement.Business
{
    using Exceptions;
    using Utility;
    public class Branch
    {
        internal List<BankAccount> BankAccounts;
        internal List<Customer> Customers;
        public int BranchId;
        /// <summary>
        /// Constructor creates Branch object with given Id and initilizes empty lists of bank acocunts and customers list.
        /// </summary>
        /// <param name="Id">Branch Id</param>
        public Branch(int Id)
        {
            BranchId = Id;
            BankAccounts = new List<BankAccount>();
            Customers = new List<Customer>();
        }
        /// <summary>
        /// Creates Bank account and Customer
        /// </summary>
        /// <param name="panNumber">Customer Pan number</param>
        /// <param name="type">Account type</param>
        /// <param name="amount">Initial Fund</param>
        /// <returns>Created Account instance is returned</returns>
        public BankAccount CreateBankAccount(string panNumber,AccountType type,double amount)
        {
            AddCustomer(panNumber);
            Customer CustomerOpeningAccount = Customers.FirstOrDefault(customer => customer.PanNumber == panNumber);//we get the customer details
            if (type == AccountType.Saving)//if type is saving account we open saving account
            {
                BankAccount Account = new SavingAccount(BankAccounts.Count+1);    //create new account object
                Account.CurrentBalance = amount;                                //initial fund set as current balance
                BankAccounts.Add(Account);                                      //add the account to accounts list
                CustomerOpeningAccount.Accounts.Add(Account);                   //add the account reference to customer list
                return Account;
            }
            else if (type == AccountType.Current)//if type is current we open current account
            {
                BankAccount Account = new CurrentAccount(BankAccounts.Count+1);
                Account.CurrentBalance = amount;
                BankAccounts.Add(Account);
                CustomerOpeningAccount.Accounts.Add(Account);
                return Account;
            }
            else
            {
                Console.WriteLine(Constants.InvalidAccountType);
            }
            return null;
        }
        private void AddCustomer(string panNumber)  //checks if the provided pan number is in customers list if not creates one
        {
            if (!Customers.Exists(customer => customer.PanNumber == panNumber)) //Customer don't exists we add customer
            {
                Customer NewCustomer = new Customer(panNumber);
                Customers.Add(NewCustomer);
            }
        }
        /// <summary>
        /// Gets the customer of given pan id
        /// </summary>
        /// <param name="panNumbe">Pan number</param>
        /// <returns>Customer object</returns>
        public Customer GetCustomerByPan(String panNumbe)
        {
            try {
            Customer RequestedCustomer= Customers.FirstOrDefault(Customer => Customer.PanNumber == panNumbe);
            if (RequestedCustomer != null)
            {
                return RequestedCustomer;
            }
            else
            {
                throw new NoCustomerFound();    //custom exception class
            }
            }
            catch
            {
                return null;    //We can handle the exception here we are returning null object and a message is displaued sayign invalid Pan
            }
        }
        /// <summary>
        /// Gets account with acccount number
        /// </summary>
        /// <param name="accountNubmer">Account number</param>
        /// <returns>BankAccount object</returns>
        public BankAccount GetAccountByAccountNumber(int accountNubmer)
        {
            try {
            BankAccount Account= BankAccounts.FirstOrDefault(Account => Account.AccountNumber == accountNubmer);
            if (Account != null)
            {
                return Account;
            }
            else
            {
                throw new NoAccountFound(); //custome exceptions class
            }
            }
            catch
            {
                return null;  //We can handle the exception here we are returning null object and a message is displaued sayign invalid Account Number
            }
        }
    }
}
