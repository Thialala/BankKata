using System;

namespace BankKata
{
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