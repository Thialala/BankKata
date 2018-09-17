using System;
using System.Collections.Generic;
using System.Linq;

namespace BankKata
{
    public class Account
    {
        public int Id { get; }

        public decimal Balance { get; private set; }

        private readonly List<Transaction> _transactions = new List<Transaction>();
        private readonly Func<DateTime> _dateProvider;

        public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

        public Account(int id, decimal initialBalance, Func<DateTime> dateProvider = null)
        {
            Id = id;
            Balance = initialBalance;
            _dateProvider = dateProvider ?? (() => DateTime.Today);
        }

        public void Transfer(decimal amount, Account toAccount)
        {
            Balance -= amount;
            toAccount.Receive(amount, this);
            _transactions.Add(new Transaction(-amount, _dateProvider(), Id, toAccount.Id));
        }

        private void Receive(decimal amount, Account fromAccount)
        {
            Balance += amount;
            _transactions.Add(new Transaction(amount, _dateProvider(), fromAccount.Id, Id));
        }

        public IEnumerable<Transaction> GetTransactionHistoryFromOrTo(int accountNumber)
        {
            return _transactions.Where(t => t.IsFromOrTo(accountNumber));
        }
    }
}