using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Bank_Management_Unit_Tests
{
    [TestClass]
    public class HeadOfficeTests
    {
        /// <summary>
        /// Creates a branch and checks if it is created or not.
        /// </summary>
        [TestMethod]
        public void BranchCreate()
        {
            BankManagement.Business.HeadOffice Delhi = new BankManagement.Business.HeadOffice();
            BankManagement.Business.Branch Hydrabad = Delhi.CreateBranch();
            Assert.AreEqual(Hydrabad, Delhi.GetBranchById(Hydrabad.BranchId.ToString()));   //checks Branch added to branch list or not
        }

        /// <summary>
        /// creates 2 branches and cheks if the list of branches in head office contain 2 branches or not.
        /// </summary>
        [TestMethod]
        public void BranchCount()
        {
            BankManagement.Business.HeadOffice Delhi = new BankManagement.Business.HeadOffice();
            BankManagement.Business.Branch Hydrabad = Delhi.CreateBranch();
            BankManagement.Business.Branch Bangalore = Delhi.CreateBranch();
            Assert.AreEqual(2,Delhi.GetAllBranches().Count);   //checks Branch added to branch list or not
        }
    }
}
