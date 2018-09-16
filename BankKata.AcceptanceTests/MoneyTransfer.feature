Feature: Successful money transfer

Scenario Outline: Successful money transfer from a payer account to a payee account 
	Given a payer account with initial balance of €<payeeInitialBalance>
	And a payee account with initial balance of €<payerInitialBalance>
	When the payer transfers €<amountToTransfer> to the payee
	Then the balance of payer account should be €<payerBalance>
	And the balance of the payee account should be €<payeeBalance>
	
	Examples: 
    | payeeInitialBalance | payerInitialBalance | amountToTransfer | payerBalance | payeeBalance |
    | 10.00               | 20.00               | 5.00             | 5.00         | 25.00        |
    | 100.00              | 50.00               | 50.00            | 50.00        | 100.00       |
    | 250.00              | 100.00              | 150.00           | 100.00       | 250.00       |
	