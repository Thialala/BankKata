using System;

namespace BankKata.AcceptanceTests
{
    internal class TransactionDetails
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
    }
}