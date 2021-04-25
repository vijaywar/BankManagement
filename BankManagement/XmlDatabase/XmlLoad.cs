using System;
using System.Collections.Generic;
using System.Text;
using BankManagement.Business;
using System.IO;
using BankManagement.DataLayer;
using System.Xml.Linq;
using System.Linq;
using BankManagement.Utility;
namespace BankManagement.XmlDatabase
{
    internal class XmlLoad
    {
        /// <summary>
        /// Starts Loading data if exists else creates a new xml
        /// </summary>
        /// <param name="headOffice">HeadOffice instance</param>
        public void LoadData(HeadOffice headOffice)
        {
            try
            {
                if (File.Exists(Constants.FilePath))
                {
                    XElement BankData = XElement.Load(Constants.FilePath);
                    var BankDataCollection = BankData.Elements(Constants.Branch);
                    LoadBranches(BankDataCollection,headOffice);
                }
                else
                {
                    XElement authors = new XElement(Constants.HeadOffice);
                    authors.Save(Constants.FilePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Loades branches in the database into the HeadBranch of instance passes
        /// </summary>
        /// <param name="bankDataCollection">XElements of branches data</param>
        /// <param name="headOffice">Head Office instance</param>
    private void LoadBranches(IEnumerable<XElement> bankDataCollection, HeadOffice headOffice)
    {
        foreach (var BranchIterator in bankDataCollection)
            {
                Branch BranchInstance = new Branch(Convert.ToInt32(BranchIterator.Element(Constants.BranchId).Value));
                var BankAccounts = BranchIterator.Elements(Constants.Accounts).Elements(Constants.Account);
                var Customers = BranchIterator.Elements(Constants.Customers).Elements(Constants.Customer);
                LoadAccounts(BankAccounts, BranchInstance);
                LoadCustomers(Customers, BranchInstance);
                headOffice.Branches.Add(BranchInstance);
            }
        }
        /// <summary>
        /// Loads customrers data into branche instance passed
        /// </summary>
        /// <param name="customers">Xelement of customers</param>
        /// <param name="branch">branch instance</param>
        private void LoadCustomers(IEnumerable<XElement> customers,  Branch branch)
        {
            foreach (var CustomerIterator in customers)
            {
                Customer CustomerInstance= new Customer(CustomerIterator.Element(Constants.PanNumber).Value);
                branch.Customers.Add(CustomerInstance);
                foreach(var Account in CustomerIterator.Elements(Constants.Accounts).Elements(Constants.Account))
                {
                    CustomerInstance.Accounts.Add(branch.BankAccounts.ElementAt(Convert.ToInt32(Account.Value)-1));
                }
            }

        }
        /// <summary>
        /// Loads Accounts data  into the branch instance passed
        /// </summary>
        /// <param name="bankAccounts">XElement of Bank Account </param>
        /// <param name="branch">branch instance</param>
        private void LoadAccounts(IEnumerable<XElement> bankAccounts,Branch branch) {
            foreach (var Account in bankAccounts)
            {
                BankAccount AccountInstance = new SavingAccount(Convert.ToInt32(Account.Element(Constants.AccountId).Value));
                AccountInstance.CurrentBalance = Convert.ToDouble(Account.Element(Constants.CurrentBalance).Value);
                LoadTransactions(Account,AccountInstance);
                branch.BankAccounts.Add(AccountInstance);
            }

        }
        /// <summary>
        /// Loads transactions into a bank account instance passed
        /// </summary>
        /// <param name="account">Xelement of account</param>
        /// <param name="accountInstance">account instance</param>
        private void LoadTransactions(XElement account,BankAccount accountInstance) {
            if (account.Element(Constants.Transactions) != null)
            {
                var Transactions = account.Elements(Constants.Transactions).Elements(Constants.Transaction);
                foreach (var transaction in Transactions)
                {
                    int Id = Convert.ToInt32(transaction.Element(Constants.TransactionId).Value);
                    double Amount = Convert.ToDouble(transaction.Element(Constants.Amount).Value);
                    Operation Type = GetOperation(transaction.Element(Constants.Type).Value);
                    Transaction TemporaryTransaction = new Transaction(Id,Amount ,Type );
                    accountInstance.Transactions.Add(TemporaryTransaction);
                }
            }
        }
        private Operation GetOperation(string operation)
        {
            if (operation == Constants.Deposit)
            {
                return Operation.Deposit; 
            }
            else
            {
                return Operation.Withdraw;
            }
        }

    }
}
