using BankManagement.Business;
using BankManagement.DataLayer;
using BankManagement.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BankManagement.XmlDatabase
{
    internal class XmlStore
    {
        /// <summary>
        /// Saves Branch data to XML takes Branch instance
        /// </summary>
        /// <param name="newBranch">Branch Instance</param>
        public void SaveBranch(Branch newBranch)
        {
            try
            {
                XElement xEle = XElement.Load(Constants.FilePath);
                if (xEle != null)
                {
                    xEle.Add(new XElement(Constants.Branch,
                        new XElement(Constants.BranchId, newBranch.BranchId),
                        new XElement(Constants.Accounts),
                        new XElement(Constants.Transactions),
                        new XElement(Constants.Customers)));
                }
                xEle.Save(Constants.FilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        /// <summary>
        /// Saves Transactions in xml into the account instance passed
        /// </summary>
        /// <param name="transaction">Transactin instance</param>
        /// <param name="account">Account instance</param>
        /// <param name="branch">Branch instance</param>
        public void SaveTransaction(Transaction transaction,BankAccount account, Branch branch)
        {
            XElement BankData = XElement.Load(Constants.FilePath);
            var BranchCollection = from BranchIterator in BankData.Elements(Constants.Branch)
                                   where (string)BranchIterator.Element(Constants.BranchId) == branch.BranchId.ToString()
                                   select BranchIterator;
            var Account = from AccountIterator in BranchCollection.Elements(Constants.Accounts).Elements(Constants.Account)
                                        where (string)AccountIterator.Element(Constants.AccountId) == account.AccountNumber.ToString()
                                        select AccountIterator;
            Account.ElementAt(0).Element(Constants.Transactions).Add(new XElement(Constants.Transaction,
                new XElement(Constants.Type, transaction.Type),
                new XElement(Constants.Amount, transaction.Amount),
                new XElement(Constants.TransactionId, transaction.TransactionId)));
            Account.ElementAt(0).Element(Constants.CurrentBalance).ReplaceNodes(account.CurrentBalance);
            BankData.Save(Constants.FilePath);
        }
        /// <summary>
        /// Saves Account into xml in branch passed
        /// </summary>
        /// <param name="account">Account instance</param>
        /// <param name="branch">Branch instance</param>
        public void SaveAccount(BankAccount account, Branch branch)
        {
            XElement BankData = XElement.Load(Constants.FilePath);
            var BranchCollection = from BranchIterator in BankData.Elements(Constants.Branch)
                                   where (string)BranchIterator.Element(Constants.BranchId) == branch.BranchId.ToString()
                                   select BranchIterator;
            BranchCollection.ElementAt(0).Element(Constants.Accounts).Add(new XElement(Constants.Account,
                new XElement(Constants.AccountId, account.AccountNumber),
                new XElement(Constants.CurrentBalance, account.CurrentBalance),
                new XElement(Constants.Transactions)));
            BankData.Save(Constants.FilePath);
        }
        /// <summary>
        /// Updates customer when a new accoutn is created adds accounts into it else creates customer
        /// </summary>
        /// <param name="account">Account Instance</param>
        /// <param name="branch">Branch Instance</param>
        /// <param name="panNumber">Pan number</param>
        internal void UpdateCustomer(BankAccount account, Branch branch, string panNumber)
        {
            XElement BankData = XElement.Load(Constants.FilePath);
            var BranchCollection = from BranchIterator in BankData.Elements(Constants.Branch)
                                   where (string)BranchIterator.Element(Constants.BranchId) == branch.BranchId.ToString()
                                   select BranchIterator;
            var Customer = BranchCollection.ElementAt(0).Elements(Constants.Customers).Elements(Constants.Customer);
           
            var Count = from customer in Customer
                            where (string)customer.Element(Constants.PanNumber) == panNumber
                            select customer;
            if (Count.Count()>0) {
                var Account = from customer in Customer
                where (string)customer.Element(Constants.PanNumber) == panNumber select customer;
                Account.ElementAt(0).Element(Constants.Accounts).Add(new XElement(Constants.Account, account.AccountNumber));
                BankData.Save(Constants.FilePath);
            }
            else
            {
                BranchCollection.ElementAt(0).Element(Constants.Customers).Add(new XElement(Constants.Customer,
                   new XElement(Constants.PanNumber, panNumber),
                   new XElement(Constants.Accounts, new XElement(Constants.Account, account.AccountNumber))));
                BankData.Save(Constants.FilePath);
            }
        }
    }
}
