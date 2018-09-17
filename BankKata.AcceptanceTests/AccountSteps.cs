using System;
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
        private DateTime _transfertDate = DateTime.Today;

        [Given(@"a payer account with initial balance of €(.*)")]
        public void GivenAPayerAccountWithInitialBalanceOf(decimal payerInitialBalance)
        {
            _payerAccount = new Account(1, payerInitialBalance, () => _transfertDate);
        }

        [Given(@"a payee account with initial balance of €(.*)")]
        public void GivenAPayeeAccountWithInitialBalanceOf(decimal payeeInitialBalance)
        {
            _payeeAccount = new Account(2, payeeInitialBalance, () => _transfertDate);
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
            _payerAccount = new Account(accountDetails.Id, accountDetails.InitialBalance);
        }

        [Given(@"a payee account with following details:")]
        public void GivenAPayeeAccountWithFollowingDetails(Table table)
        {
            var accountDetails = table.CreateInstance<AccountDetails>();
            _payeeAccount = new Account(accountDetails.Id, accountDetails.InitialBalance); ;
        }

        [Then(@"the payer account should have a transaction with following details")]
        public void ThenThePayerAccountShouldHaveATransactionWithFollowingDetails(Table table)
        {
            var transactionsDetails = table.CreateInstance<TransactionDetails>();
            var expectedTransaction = new Transaction(transactionsDetails.Amount,
                transactionsDetails.Date,
                transactionsDetails.FromAccountId,
                transactionsDetails.ToAccountId);

            _payerAccount.Transactions.Should().Contain(expectedTransaction);
        }

        [Then(@"the payee should have a transaction with following details")]
        public void ThenThePayeeShouldHaveATransactionWithFollowingDetails(Table table)
        {
            var transactionsDetails = table.CreateInstance<TransactionDetails>();
            var expectedTransaction = new Transaction(transactionsDetails.Amount,
                transactionsDetails.Date,
                transactionsDetails.FromAccountId,
                transactionsDetails.ToAccountId);

            _payeeAccount.Transactions.Should().Contain(expectedTransaction);
        }
    }
}