using System.Collections.Generic;

namespace BankKata.AcceptanceTests
{
    public class Account
    {
        public int Id { get; }

        public decimal Balance { get; private set; }

        public IList<Transaction> Transactions { get; set; }

        public Account(int id, decimal initialBalance)
        {
            Id = id;
            Balance = initialBalance;
        }

        public void Transfer(decimal amount, Account toAccount)
        {
            Balance -= amount;
            toAccount.Receive(amount, this);
        }

        private void Receive(decimal amount, Account fromAccount)
        {
            Balance += amount;
        }
    }

    public class Transaction
    {
        private decimal amount;

        public Transaction(decimal amount)
        {
            this.amount = amount;
        }
    }
}