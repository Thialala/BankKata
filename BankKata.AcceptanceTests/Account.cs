using System;
using System.Collections.Generic;
using System.Linq;

namespace BankKata.AcceptanceTests
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

    public class Transaction
    {
        private readonly decimal _amount;
        private readonly DateTime _date;
        private readonly int _fromAccountId;
        private readonly int _toAccountId;

        public Transaction(decimal amount, DateTime date, int fromAccountId, int toAccountId)
        {
            _amount = amount;
            _date = date;
            _fromAccountId = fromAccountId;
            _toAccountId = toAccountId;
        }

        public override bool Equals(object obj)
        {
            return obj is Transaction transaction &&
                   _amount == transaction._amount &&
                   _date == transaction._date &&
                   _fromAccountId == transaction._fromAccountId &&
                   _toAccountId == transaction._toAccountId;
        }

        public override int GetHashCode()
        {
            var hashCode = 1633290279;
            hashCode = hashCode * -1521134295 + _amount.GetHashCode();
            hashCode = hashCode * -1521134295 + _date.GetHashCode();
            hashCode = hashCode * -1521134295 + _fromAccountId.GetHashCode();
            hashCode = hashCode * -1521134295 + _toAccountId.GetHashCode();
            return hashCode;
        }

        public bool IsFromOrTo(int accountNumber)
        {
            return _fromAccountId == accountNumber || _toAccountId == accountNumber;
        }
    }
}