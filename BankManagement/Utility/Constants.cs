using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagement.Utility
{
    internal static class Constants
    {
        public static string FilePath = @"BankData.xml";
        public static string LauncherDisplay= "\nWelcome Please select ur option from the following\nPress 1 for HeadOffice Controls\nPress 2 for Branch Controls\nPress 3 for Account Controls\nPress 4 to Exit";
        public static string BranchDisplay = "\nBranchOffice\n\nPress 1 to create a Account\nPress 2 to get Account with Account Number\nPress 3 to get Customer Details\nPress 4 to go Back";
        public static string AccountDisplay = "\nAccount Operations\nPress 1 to view Balance\nPress 2 to Deposit\nPress 3 to Withdraw\nPress 4 to get MiniStatement\nPress 5 to get Statement\nPress 6 to go Back";
        public static string HeadOfficeDisplay = "\nHeadoffice\nPress 1 to create a New Branch\nPress 2 to get Branch by ID\nPress 3 to list all Branches\nPress 4 to Go Back";

        public static string Greetings = "Hello Welcome!";
        public static string ErrorMessage = "Error with this exception throw  :";


        public static string InvalidPanNumber = "Invalid Customer Pan Number!";
        public static string InvalidAccountNumber = "Invalid Account Number!";
        public static string InvalidAccountType = "Invalid Account Type!";
        public static string InvalidBranchId = "Invalid Branch Id Branch doesn't exists";
        public static string InvalidInput = "\nSorry Invalid Input Try Again!\n";

        public static string Branch = "Branch";
        public static string BranchId = "BranchId";
        public static string Account = "Account";
        public static string Accounts = "Accounts";
        public static string AccountId = "AccountId";
        public static string CurrentBalance = "CurrentBalance";
        public static string HeadOffice = "HeadOffice";
        public static string Transaction = "Transaction";
        public static string Transactions = "Transactions";
        public static string TransactionId = "TransactionId";
        public static string Amount = "Amount"; 
        public static string Type = "Type";
        public static string Customers = "Customers";
        public static string Customer = "Customer";
        public static string PanNumber = "PanNumber";
        public static string Deposit = "Deposit";
        public static string Withdraw = "Withdraw";

        public static string EnterDepositAmount = "Enter Deposit Amount :";
        public static string EnterWithdrawAmount = "Enter Withdraw Amount :";
        public static string EnterAmountInitalDeposit = "ENter Amount to Deposit Initally: ";
        public static string EnterBranchId = "Enter Branch ID: ";
        public static string EnterAccountNumber = "Enter Account NO: ";
        public static string EnterPanNumber = "Enter Pan ID: ";
        public static string ChooseAccountType = "Press 1 for Saving Account\nPress 2 for Current Account";

       

        public static string TransactionIdDisplay = "Transaction ID :";
        public static string AmountDisplay = "Amount :";
        public static string TypeDiplay = "Type :";
        public static string BranchIdIs = "Branch ID is:";
        public static string BranchHasAccounts = "  Branch has Accounts ";
        public static string PanNumberDisplay = "PAN Number: ";
        public static string AccountsCount = "Accounts Hold: "; 
        public static string BalanceDisplay = "Balance :";
        public static string AccountNumberDisplay = "Account Number: ";
        public static string BranchIdDisplay = "Branch Id : ";
        public static string EndMessage = "\n********************* Thank you ********************\n";
        public static string Dashes = "--------------------------------------------------------------------------------\n";
        public static string BranchCreated = "\nBranch Created  Successful with ID :";
        public static string AccountOpenSuccess = "\nAccoutn opened Successful with ID :";
        public static string Deposited = "\nAmount Deposited to Account Successfully!";
        public static string Withdrawed = "\nAmount Deducted from  Account Successfully!";
    }
}
