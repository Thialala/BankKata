using FluentAssertions;
using TechTalk.SpecFlow;

namespace BankKata.AcceptanceTests
{
    [Binding]
    public class SuccessfulMoneyTransferSteps
    {
        private Account _payerAccount;
        private Account _payeeAccount;

        [Given(@"a payer account with initial balance of €(.*)")]
        public void GivenAPayerAccountWithInitialBalanceOf(decimal payerInitialBalance)
        {
            _payerAccount = new Account(1, payerInitialBalance);
        }

        [Given(@"a payee account with initial balance of €(.*)")]
        public void GivenAPayeeAccountWithInitialBalanceOf(decimal payeeInitialBalance)
        {
            _payeeAccount = new Account(2, payeeInitialBalance);
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
    }
}
