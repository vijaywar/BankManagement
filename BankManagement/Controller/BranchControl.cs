using BankManagement.Business;
using BankManagement.DataLayer;
using System;
using System.Linq;
using System.Xml.Linq;

namespace BankManagement.Controller
{
    using Utility;
    using XmlDatabase;
    public class BranchControl
    {
        AccountControl AccountController;//Account Controller Instance
        UserInput InputTaker = new UserInput();
        public BranchControl()
        {
            AccountController = new AccountControl();
        }
        /// <summary>
        /// Displays all Branch Controls Available to perform some action
        /// </summary>
        /// <param name="branch">Branch Instance</param>
        public void BranchControls(Branch branch)
        {
            Console.WriteLine(Constants.BranchIdDisplay+ branch.BranchId);
            Console.WriteLine(Constants.BranchDisplay);
            try
            {
                int UserInput = InputTaker.GetIntInput(1,4);
                Console.Clear();
                switch (UserInput)
                {
                    case 1:
                        OpenAccount(branch);
                        BranchControls(branch);
                        break;
                    case 2:
                        GetAccount(branch);
                        BranchControls(branch);
                        break;
                    case 3:
                        GetCustomer(branch);
                        BranchControls(branch);
                        break;
                    case 4:
                        break;
                    default:
                        BranchControls(branch);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Takes Account Opening Details and Opens Account
        /// </summary>
        /// <param name="branch"></param>
         public void OpenAccount(Branch branch)
        {
            Console.WriteLine(Constants.EnterPanNumber);    
            string PanNumber = Console.ReadLine();     //takes pan input
            AccountType Type = InputTaker.GetAccountType(); //takes Account type input
            Console.WriteLine(Constants.EnterAmountInitalDeposit); 
            double Amount =InputTaker.GetDoubleInput(0);    //takes amount to deposit initially

            BankAccount Account = branch.CreateBankAccount(PanNumber,Type, Amount);
            try
            {
                XmlStore Store = new XmlStore();                
            Store.SaveAccount(Account,branch);              //Saves to xml
            Store.UpdateCustomer(Account, branch, PanNumber);
            Console.WriteLine(Constants.AccountOpenSuccess + Account.AccountNumber);
            
                Transaction FirstTransaction = new Transaction(1, Amount, Operation.Deposit);
                Store.SaveTransaction(FirstTransaction, Account, branch);
            }
            catch(Exception ex) { Console.WriteLine("Erorr in this line 79 :"+ex); }
          
        }
       /// <summary>
       /// Takes Account Id and branch Id as input and diplya a list of actions available to do on that account
       /// </summary>
       /// <param name="branch">Takes branch instanc</param>
       public void GetAccount(Branch branch)
        {
            Console.WriteLine(Constants.EnterAccountNumber);
            int AccountNumber = InputTaker.GetIntInput(1);
                BankAccount Account = branch.GetAccountByAccountNumber(AccountNumber);
                if (Account != null)
                {
                    Console.WriteLine(Constants.AccountNumberDisplay + Account.AccountNumber);
                    Console.WriteLine(Constants.BalanceDisplay + Account.CurrentBalance);
                    Console.WriteLine(Constants.Dashes);
                    AccountController.AccountControler(Account,branch);
                }
                else
                {
                    Console.WriteLine(Constants.InvalidAccountNumber);
                }
        }
        /// <summary>
        /// Asks for pan number and displays customer details
        /// </summary>
        /// <param name="branch"></param>
         public void GetCustomer(Branch branch)
        {
            Console.WriteLine(Constants.EnterPanNumber);
            string PanNumber = Console.ReadLine();
            Customer Customer1 = branch.GetCustomerByPan(PanNumber);
            if (Customer1 != null)
            {
                Console.WriteLine(Constants.PanNumberDisplay + Customer1.PanNumber);
                Console.WriteLine(Constants.AccountsCount+ Customer1.Accounts.Count);
            }
            else
            {
                Console.WriteLine(Constants.InvalidPanNumber);
            }
        }
    }
}
