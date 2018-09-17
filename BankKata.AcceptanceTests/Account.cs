using System.Collections.Generic;

namespace BankKata.AcceptanceTests
{
    public class Account
    {
        public int Id { get; }

        public decimal Balance { get; private set; }

        private readonly List<Transaction> _transactions = new List<Transaction>();

        public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

        public Account(int id, decimal initialBalance)
        {
            Id = id;
            Balance = initialBalance;
        }

        public void Transfer(decimal amount, Account toAccount)
        {
            Balance -= amount;
            toAccount.Receive(amount, this);
            _transactions.Add(new Transaction(-amount));
        }

        private void Receive(decimal amount, Account fromAccount)
        {
            Balance += amount;
            _transactions.Add(new Transaction(amount));
        }
    }

    public class Transaction
    {
        private readonly decimal _amount;

        public Transaction(decimal amount)
        {
            _amount = amount;
        }

        public override bool Equals(object obj)
        {
            return obj is Transaction transaction &&
                   _amount == transaction._amount;
        }

        public override int GetHashCode()
        {
            return -1658239311 + _amount.GetHashCode();
        }
    }
}