using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace BankManagement.Business
{
    public class HeadOffice
    {
        public List<Branch> Branches;
        /// <summary>
        /// Constructor initilizes the Brances list
        /// </summary>
        public HeadOffice()
        {
            Branches = new List<Branch>();
        }
        /// <summary>
        /// Creates a new branch and adds to the list of brances
        /// </summary>
        /// <returns>Branch instance created</returns>
        public Branch CreateBranch()
        {
            Branch BranchCreated = new Branch(Branches.Count + 1);
            Branches.Add(BranchCreated);
            return BranchCreated;
        }
        /// <summary>
        /// returns branch instance of the given branch id.
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns>Branch object</returns>
        public Branch GetBranchById(String branchId)
        {
            return Branches.FirstOrDefault(branch => branch.BranchId.ToString().Equals(branchId));
        }
        /// <summary>
        /// returns all the branches created
        /// </summary>
        /// <returns>list of Branche</returns>
        public List<Branch> GetAllBranches()
        {
            return Branches;
        }
    }
}
