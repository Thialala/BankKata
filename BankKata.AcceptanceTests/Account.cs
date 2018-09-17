﻿namespace BankKata.AcceptanceTests
{
    public class Account
    {
        public int Id { get; }

        public decimal Balance { get; private set; }

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
}