using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagement.Exceptions
{
    using Utility;
    public class NoCustomerFound : Exception
    {
        public NoCustomerFound() : base()
        {
            Console.WriteLine(Constants.InvalidPanNumber);
        }

    }
}
