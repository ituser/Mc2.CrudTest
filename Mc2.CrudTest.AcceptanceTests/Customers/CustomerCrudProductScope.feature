Feature: Customer Create Read Edit Delete Product Scope

Background:
	Given System error codes are following
		| Code | Description                                                |
		| 101  | Invalid Mobile Number                                      |
		| 102  | Invalid Email address                                      |
		| 103  | Invalid Bank Account Number                                |
		| 201  | Duplicate customer by First-name, Last-name, Date-of-Birth |
		| 202  | Duplicate customer by Email address                        |

Scenario Outline: Create Read Edit Delete Customer
	When user creates customer with <FirstName>
	And lastname of <LastName>
	And date of birth of <DateOfBirth>
	And email of <Email>
	And Phone number of <PhoneNumber>
	Then user can lookup customer by ID of <ID> and get "1" records
	When user edit customer by ID of <ID> with new email of "new@email.com"
	Then user can lookup customer by ID of <ID> and get "1" records
	And return record email is "new@email.com"
	When user delete customer by ID of <ID>
	Then user can lookup customer by ID of <ID> and get "0" records

	Examples:
		| ID | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
		| 1  | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |

Scenario: Create a duplicate customer by firstname, lastname and date of birth
	Given system has existing customer
		| ID | FirstName | LastName | Email        | DateOfBirth | BankAccountNumber | PhoneNumber   |
		| 1  | JOHN      | DOE      | john@doe.com | 01-JAN-2000 | IR000000000000001 | +989123491682 |
	When user creates customer with <FirstName>
	And lastname of <LastName>
	And date of birth of <DateOfBirth>
	And email of <Email>
	Then system responds with "201"  error

	Examples:
		| ID | FirstName | LastName | Email        | DateOfBirth | BankAccountNumber | PhoneNumber   |
		| 1  | John      | Doe      | john@doe.com | 01-JAN-2000 | IR000000000000001 | +989123491682 |