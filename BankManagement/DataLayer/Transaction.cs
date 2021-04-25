using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagement.DataLayer
{
    public class Transaction
    {
        public long TransactionId { get; set; }
        public Double Amount { get; set; }
        public Operation Type { get; set; }
        /// <summary>
        /// Creates a transaction
        /// </summary>
        /// <param name="id">ID of the transaction</param>
        /// <param name="amount">Amount Processed</param>
        /// <param name="type">Type of the operation</param>
        public Transaction(long id,double amount,Operation type)
        {
            TransactionId = id;
            Amount = amount;
            Type = type;
        }
        
    }
}
