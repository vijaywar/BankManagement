using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagement.Exceptions
{
    using Utility;
    public class NoAccountFound : Exception
    {
        public NoAccountFound() : base()
        {
            Console.WriteLine(Constants.InvalidAccountNumber);
        }

    }
}
