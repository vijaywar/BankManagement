using BankManagement.Business;
using System;
using System.Collections.Generic;

namespace BankManagement.Controller
{
    using BankManagement.XmlDatabase;
    using Utility;
     public class HeadOfficeControl
    {
       /// <summary>
       /// DIsplays opitons a HeadOffice can do and performs actions as user input
       /// </summary>
       /// <param name="branchController">BranchController Instance</param>
       /// <param name="headOfficeName">HeadOffice Instance</param>
        public void HeadOfficeControls(BranchControl branchController,HeadOffice headOfficeName)
        {
            Console.WriteLine(Constants.HeadOfficeDisplay);
            try
            {
                int InputOption = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (InputOption)
                {
                    case 1:
                        CreateNewBranch(branchController,headOfficeName);
                        break;
                    case 2:
                        GetBranchById(branchController, headOfficeName);
                        break;
                    case 3:
                        ListBranches(headOfficeName.GetAllBranches());
                        HeadOfficeControls(branchController,headOfficeName);
                        break;
                    case 4:
                        break;
                    default:
                        HeadOfficeControls(branchController,headOfficeName);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Creates new branch and saves to xml file
        /// </summary>
        /// <param name="branchController">Branch Instance</param>
        /// <param name="headOfficeName">HeadOffice Instance</param>
        public void CreateNewBranch(BranchControl branchController, HeadOffice headOfficeName)
        {
            Branch NewBranch = headOfficeName.CreateBranch();   //creates a new branch and returns branch instance
            XmlStore XmlDatabase = new XmlStore();          
            XmlDatabase.SaveBranch(NewBranch);         //Saves created branch to xml file
            Console.WriteLine(Constants.BranchCreated + NewBranch.BranchId);
            HeadOfficeControls(branchController, headOfficeName); //Restarts the Application
        }
        /// <summary>
        /// Asks for Branch id and gives options to do actions in that branch
        /// </summary>
        /// <param name="branchController"></param>
        /// <param name="headOfficeName"></param>
        public void GetBranchById(BranchControl branchController, HeadOffice headOfficeName)
        {
            Console.WriteLine(Constants.EnterBranchId);
            string BranchId = Console.ReadLine();
            Branch BranchInstance = headOfficeName.GetBranchById(BranchId);
            if (BranchInstance != null)
            {
                branchController.BranchControls(BranchInstance);//Diplays list options to do actions
            }
            else
            {
                Console.WriteLine(Constants.InvalidBranchId);
            }
            HeadOfficeControls(branchController, headOfficeName);
        }
        /// <summary>
        /// Displayse the Branches passes as List to user
        /// </summary>
        /// <param name="Branches">Branch List</param>
        public void ListBranches(List<Branch> Branches)
        {
            Console.WriteLine("\nAll Branches List :\n");
            foreach (Branch branch in Branches)
            {
                Console.WriteLine(Constants.BranchIdIs+branch.BranchId+Constants.BranchHasAccounts+branch.BankAccounts.Count);
            }
            Console.WriteLine(Constants.EndMessage);
        }
    }
}
