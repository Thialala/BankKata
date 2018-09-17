using System;
using BankKata.AcceptanceTests.Support;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BankKata.AcceptanceTests
{
    [Binding]
    public class SuccessfulMoneyTransferSteps
    {
        private Account _payerAccount;
        private Account _payeeAccount;
        private Account _thirdAccount;
        private DateTime _transfertDate = DateTime.Today;

        [Given(@"a payer account with initial balance of €(.*)")]
        public void GivenAPayerAccountWithInitialBalanceOf(decimal payerInitialBalance)
        {
            _payerAccount = BuildAccount(new AccountDetails { Id = 1, InitialBalance = payerInitialBalance });
        }

        [Given(@"a payee account with initial balance of €(.*)")]
        public void GivenAPayeeAccountWithInitialBalanceOf(decimal payeeInitialBalance)
        {
            _payeeAccount = BuildAccount(new AccountDetails { Id = 2, InitialBalance = payeeInitialBalance });
        }

        [When(@"the payer transfers €(.*) to the payee")]
        public void WhenThePayerTransfersToThePayee(decimal amountToTransfer)
        {
            _payerAccount.Transfer(amountToTransfer, _payeeAccount);
        }

        [Then(@"the balance of payer account should be €(.*)")]
        public void ThenTheBalanceOfPayerAccountShouldBe(decimal payerBalance)
        {
            _payerAccount.Balance.Should().Be(payerBalance);
        }

        [Then(@"the balance of the payee account should be €(.*)")]
        public void ThenTheBalanceOfThePayeeAccountShouldBe(decimal payeeBalance)
        {
            _payeeAccount.Balance.Should().Be(payeeBalance);
        }

        [Given(@"the transfer date is (.*)")]
        public void GivenTheTransferDateIs(DateTime transferDate)
        {
            _transfertDate = transferDate;
        }

        [Given(@"a payer account with following details:")]
        public void GivenAPayerAccountWithFollowingDetails(Table table)
        {
            var accountDetails = table.CreateInstance<AccountDetails>();
            _payerAccount = BuildAccount(accountDetails);
        }

        [Given(@"a payee account with following details:")]
        public void GivenAPayeeAccountWithFollowingDetails(Table table)
        {
            var accountDetails = table.CreateInstance<AccountDetails>();
            _payeeAccount = BuildAccount(accountDetails);
        }

        [Then(@"the payer account should have a transaction with following details")]
        public void ThenThePayerAccountShouldHaveATransactionWithFollowingDetails(Table table)
        {
            var expectedTransaction = BuildExpectedTransaction(table.CreateInstance<TransactionDetails>());
            _payerAccount.Transactions.Should().Contain(expectedTransaction);
        }

        [Then(@"the payee should have a transaction with following details")]
        public void ThenThePayeeShouldHaveATransactionWithFollowingDetails(Table table)
        {
            var expectedTransaction = BuildExpectedTransaction(table.CreateInstance<TransactionDetails>());
            _payeeAccount.Transactions.Should().Contain(expectedTransaction);
        }

        [Given(@"a third account with following details:")]
        public void GivenAThirdAccountWithFollowingDetails(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the payer transfers €(.*) to the third account")]
        public void WhenThePayerTransfersToTheThirdAccount(decimal amount)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"querying transaction history on payee account for account number (.*) should return the following transaction")]
        public void WhenQueryingTransactionHistoryOnPayeeAccountForAccountNumberShouldReturnTheFollowingTransaction(int accountNumber, Table table)
        {
            ScenarioContext.Current.Pending();
        }


        private Account BuildAccount(AccountDetails accountDetails)
        {
            return new Account(accountDetails.Id, accountDetails.InitialBalance, () => _transfertDate);
        }

        private static Transaction BuildExpectedTransaction(TransactionDetails transactionsDetails)
        {
            return new Transaction(transactionsDetails.Amount,
                transactionsDetails.Date,
                transactionsDetails.FromAccountId,
                transactionsDetails.ToAccountId);
        }
    }
}