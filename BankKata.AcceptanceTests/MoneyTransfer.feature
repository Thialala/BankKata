﻿Feature: Successful money transfer

Scenario Outline: Successful money transfer from a payer account to a payee account
	Given a payer account with initial balance of €<payeeInitialBalance>
		And a payee account with initial balance of €<payerInitialBalance>
	When the payer transfers €<amountToTransfer> to the payee
	Then the balance of payer account should be €<payerBalance>
		And the balance of the payee account should be €<payeeBalance>

	Examples:
    | payeeInitialBalance | payerInitialBalance | amountToTransfer | payerBalance | payeeBalance |
    | 10,00               | 20,00               | 5,00             | 5,00         | 25,00        |
    | 100,00              | 50,00               | 50,00            | 50,00        | 100,00       |
    | 250,00              | 100,00              | 150,00           | 100,00       | 250,00       |

Scenario:  Keep a record of the transfer for both bank accounts in a transaction history
    Given the transfer date is 17/09/2018
		And a payer account with following details:
		| Id | InitialBalance |
		| 1  | 100,00         |
		And a payee account with following details:
		| Id | InitialBalance |
		| 2  | 100,00         |
	When the payer transfers €50,00 to the payee
	Then the payer account should have a transaction with following details
	| amount | date       | fromAccountId | toAccountId |
	| -50,00 | 17/09/2018 | 1             | 2           |
		And the payee should have a transaction with following details
		| amount | date       | fromAccountId | toAccountId |
		| 50,00  | 17/09/2018 | 1             | 2           |

Scenario: Query a bank account's transaction history for any bank transfers to or from a specific account
    Given the transfer date is 17/09/2018
		And a payer account with following details:
		| Id | InitialBalance |
		| 1  | 100,00         |
		And a payee account with following details:
		| Id | InitialBalance |
		| 2  | 100,00         |
		And a third account with following details:
		| Id | InitialBalance |
		| 3  | 50,00          |
	When the payer transfers €70,00 to the payee
		And the payer transfers €30,00 to the third account
	Then querying transaction history on payer account for account number 2 should return the following transaction
	| amount | date       | fromAccountId | toAccountId |
	| -70,00 | 17/09/2018 | 1             | 2           |
		And querying transaction history on payer account for account number 3 should return the following transaction
		| amount | date       | fromAccountId | toAccountId |
		| -30,00 | 17/09/2018 | 1             | 3           |




