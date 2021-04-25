using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Bank_Management_Unit_Tests
{
    [TestClass]
    public class AccountTests
    {
        /// <summary>
        /// Deposits into accounts and checks if the current balance is updated or not
        /// </summary>
        [TestMethod]
        public void Deposit()
        {
            BankManagement.Business.BankAccount Account = new BankManagement.Business.SavingAccount(1);
            Account.CurrentBalance = 200;
            Account.Deposit(500);
            Assert.AreEqual(700,Account.CurrentBalance);
        }
        /// <summary>
        /// Withdraws form a account and checks if the amound is deducted form the account balance or not
        /// </summary>
        [TestMethod]
        public void Withdraw()
        {
            BankManagement.Business.BankAccount Account = new BankManagement.Business.SavingAccount(1);
            Account.CurrentBalance = 2200;
            Account.Withdraw(1000);
            Assert.AreEqual(1200, Account.GetCurrentBalance());
        }
        /// <summary>
        /// Chekcs if the funciton cu
        /// </summary>
        [TestMethod]
        public void BalanceCheck()
        {
            BankManagement.Business.BankAccount Account = new BankManagement.Business.SavingAccount(1);
            Account.CurrentBalance = 3200;
            Assert.AreEqual(3200, Account.CurrentBalance);
        }
        [TestMethod]
        public void AccounTypeSaving()
        {
            BankManagement.Business.BankAccount Account = new BankManagement.Business.SavingAccount(1);
            Assert.AreEqual(BankManagement.DataLayer.AccountType.Saving, Account.GetAccountType());
        }
        [TestMethod]
        public void AccountTypeCurrent()
        {
            BankManagement.Business.BankAccount Account = new BankManagement.Business.CurrentAccount(1);
            Assert.AreEqual(BankManagement.DataLayer.AccountType.Current, Account.GetAccountType());
        }
    }
}
