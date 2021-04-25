using System;
using BankManagement.Controller;
namespace BankManagement
{
    using Utility;
    internal class Program
    {
        static void Main(string[] args)
        {
            try {
            Console.WriteLine(Constants.Greetings);
            Launcher Launcher = new Launcher();
            Launcher.Controls();
            }
            catch(Exception ex)
            {
                Console.WriteLine(Constants.ErrorMessage + ex.Message);
            }
        }
    }
}
