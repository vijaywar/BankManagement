using System;
using BankManagement.Business;
using BankManagement.Utility;
namespace BankManagement.Controller
{
    using XmlDatabase;
    public class Launcher
    {
        HeadOffice HeadOfficeName;
        HeadOfficeControl HeadOfficeController;
        BranchControl Branch1;
        UserInput InputTaker;
        /// <summary>
        /// Initializes A HeadOffice and Loads Data it xml data exist else creats a new xml
        /// </summary>
        public Launcher()
        {
            Branch1 = new BranchControl();
            HeadOfficeName = new HeadOffice();
            HeadOfficeController = new HeadOfficeControl();
            InputTaker = new UserInput();
            XmlLoad XmlLoader = new XmlLoad();
            XmlLoader.LoadData(HeadOfficeName);
        }
        /// <summary>
        /// Starts the Applications and Displays Control options
        /// </summary>
        public void Controls()
        {
            Console.WriteLine(Constants.LauncherDisplay);
            try {
                int UserInput = InputTaker.GetIntInput(1,4);
                Console.Clear();
                switch (UserInput)
                {
                    case 1:
                        HeadOfficeController.HeadOfficeControls(Branch1, HeadOfficeName);   //HeadOffice controls will open
                        Controls();
                        break;
                    case 2:
                        BranchController();
                        break;
                    case 3:
                        AccountControler();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine(Constants.InvalidInput);
                        Controls();
                        break;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Takes Branch Id as input and opens Branch Controls
        /// </summary>
        public void BranchController()
        {
            Console.WriteLine(Constants.EnterBranchId);
            string BranchId = Console.ReadLine();
            Branch1.BranchControls(HeadOfficeName.GetBranchById(BranchId));
            Controls();
        }
        /// <summary>
        /// Takes Account Id and Branch Id as input and Opens Account Controls
        /// </summary>
        public void AccountControler()
        {
            Console.WriteLine(Constants.EnterBranchId);
            string BranchId = Console.ReadLine();
            Branch TemporaryBranch = HeadOfficeName.GetBranchById(BranchId);
            if (TemporaryBranch != null)
                Branch1.GetAccount(TemporaryBranch);
            else
                Console.WriteLine(Constants.InvalidBranchId);
            Controls();
        }
     
    }
}
