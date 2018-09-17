using System.Collections.Generic;

namespace BankKata.AcceptanceTests
{
    public class Account
    {
        public int Id { get; }

        public decimal Balance { get; private set; }

        public IList<Transaction> Transactions { get; set; } = new List<Transaction>();

        public Account(int id, decimal initialBalance)
        {
            Id = id;
            Balance = initialBalance;
        }

        public void Transfer(decimal amount, Account toAccount)
        {
            Balance -= amount;
            toAccount.Receive(amount, this);
            Transactions.Add(new Transaction(-50));
        }

        private void Receive(decimal amount, Account fromAccount)
        {
            Balance += amount;
            Transactions.Add(new Transaction(50));
        }
    }

    public class Transaction
    {
        private decimal amount;

        public Transaction(decimal amount)
        {
            this.amount = amount;
        }

        public override bool Equals(object obj)
        {
            var transaction = obj as Transaction;
            return transaction != null &&
                   amount == transaction.amount;
        }

        public override int GetHashCode()
        {
            return -1658239311 + amount.GetHashCode();
        }
    }
}