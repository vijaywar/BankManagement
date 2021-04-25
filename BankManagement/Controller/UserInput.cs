using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagement.Controller
{
    using Utility;
    using Exceptions;
    using BankManagement.DataLayer;
    public class UserInput
    {
        /// <summary>
        /// Retrns a int value with all exceptions handled
        /// </summary>
        /// <param name="minimum">Minium value</param>
        /// <param name="maximum">maximum Value</param>
        /// <returns>And valid int value</returns>
        public int GetIntInput(int minimum,int maximum=int.MaxValue)
        {
            try {
                int UserOption = Convert.ToInt32(Console.ReadLine());
                if(UserOption>=minimum && UserOption <= maximum)
                {
                    return UserOption;
                }
                else
                {
                    throw new InvalidInputException();
                }
            }
            catch
            {
                Console.WriteLine(Constants.InvalidInput);
                return GetIntInput(minimum,maximum);
            }
        }
        /// <summary>
        /// Takes Double as input with all exceptions hadled
        /// </summary>
        /// <param name="minimum">Minimum value</param>
        /// <returns>A valid double greter than 0</returns>
        public Double GetDoubleInput(int minimum)
        {
            try
            {
                Double UserOption = Convert.ToDouble(Console.ReadLine());
                if (UserOption >= minimum)
                {
                    return UserOption;
                }
                else
                {
                    throw new InvalidInputException();
                }
            }
            catch
            {
                Console.WriteLine(Constants.InvalidInput);
                return GetDoubleInput(minimum);
            }
        }
        /// <summary>
        /// Displays available account types and asks for user choice
        /// </summary>
        /// <returns>Account Type</returns>
        public AccountType GetAccountType()
        {
            Console.WriteLine(Constants.ChooseAccountType);
            try
            {
                int UserInput = Convert.ToInt32(Console.ReadLine());
                if (UserInput == 1) { return AccountType.Saving; }
                else if (UserInput == 2) { return AccountType.Current; }
                else
                {
                    Console.WriteLine(Constants.InvalidInput);
                    return GetAccountType();
                }
            }
            catch
            {
                Console.WriteLine(Constants.InvalidInput);
                return GetAccountType();
            }
        }

    }
}
