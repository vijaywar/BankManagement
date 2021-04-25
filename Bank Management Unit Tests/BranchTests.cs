using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Bank_Management_Unit_Tests
{
    [TestClass]
    public class BranchTests
    {
        /// <summary>
        /// Creates a account and checks if it is added to list of accounts in a branch or not.
        /// </summary>
        [TestMethod]
        public void AccountCreate()
        {
            BankManagement.Business.Branch Hydrabad = new BankManagement.Business.Branch(1);
            BankManagement.Business.BankAccount Vijay= Hydrabad.CreateBankAccount("FINE789",BankManagement.DataLayer.AccountType.Current,2000);

            Assert.AreEqual(Vijay, Hydrabad.GetAccountByAccountNumber((int)Vijay.AccountNumber));   //checks account created or not
        }

       
        /// <summary>
        /// Creates a customer and adds 2 accounts to it and checks if 2 accoutns added to it or not
        /// </summary>
        [TestMethod]
        public void Customer()
        {
            BankManagement.Business.Branch Hydrabad = new BankManagement.Business.Branch(1);
            BankManagement.Business.BankAccount Vijay1 = Hydrabad.CreateBankAccount("FINE789", BankManagement.DataLayer.AccountType.Current, 2000);
            BankManagement.Business.BankAccount Vijay2 = Hydrabad.CreateBankAccount("FINE789", BankManagement.DataLayer.AccountType.Saving, 4000);

            Assert.AreEqual(Hydrabad.GetCustomerByPan("FINE789").Accounts.Count, 2);//Checks if customer holds 2 accoutns or not.
        }
    }
}
