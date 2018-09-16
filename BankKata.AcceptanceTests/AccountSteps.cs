using System;
using TechTalk.SpecFlow;

namespace BankKata.AcceptanceTests
{
    [Binding]
    public class SuccessfulMoneyTransferSteps
    {
        [Given(@"a payer account with initial balance of €(.*)")]
        public void GivenAPayerAccountWithInitialBalanceOf(decimal payerInitialBalance)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"a payee account with initial balance of €(.*)")]
        public void GivenAPayeeAccountWithInitialBalanceOf(decimal payeeInitialBalance)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the payer transfers €(.*) to the payee")]
        public void WhenThePayerTransfersToThePayee(decimal amountToTransfer)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the balance of payer account should be €(.*)")]
        public void ThenTheBalanceOfPayerAccountShouldBe(decimal payerBalance)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the balance of the payee account should be €(.*)")]
        public void ThenTheBalanceOfThePayeeAccountShouldBe(decimal payeeBalance)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
