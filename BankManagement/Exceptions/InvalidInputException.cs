using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagement.Exceptions
{
    using Utility;
    public class InvalidInputException : Exception
    {
            public InvalidInputException() : base()
            {
                Console.WriteLine(Constants.InvalidInput);
            }
        
    }
}
