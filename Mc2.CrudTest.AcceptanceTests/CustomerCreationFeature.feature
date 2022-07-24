Feature: CustomerFeature
As an admin,
In order to mange customer,
I need to be able create/edit/delete customer

@Customer
Scenario: Customer with valid info should be registered
	Given I enter following values for new customer
		| FirstName | LastName  | DateOfBirth | PhoneNumber    | Email                   | BankAccountNumber                 |
		| Roya      | Allahyari | 1984-04-11  | 00989123491682 | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 |
	When I press Submit button
	Then I should not get any exception

Scenario: Customer with existing name, family and date of birth should be rejected
	Given There is a customer by values FirstName 'Roya', LastName 'Allahyari', DateOfBirth '1984-04-11'
	And I enter following values for new customer
		| FirstName | LastName  | DateOfBirth | PhoneNumber    | Email                   | BankAccountNumber                 |
		| Roya      | Allahyari | 1984-04-11  | 00989123491682 | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 |
	When I press Submit button
	Then I should get 'DuplicateCustomerException' exception

Scenario: Customer with null firstName should be rejected
	Given I enter following values for new customer
		| FirstName | LastName  | DateOfBirth | PhoneNumber    | Email                   | BankAccountNumber                 |
		|           | Allahyari | 1984-04-11  | 00989123491682 | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 |
	When I press Submit button
	Then I should get 'FirstNameRequiredException' exception

Scenario: Customer with null lastName should be rejected
	Given I enter following values for new customer
		| FirstName | LastName | DateOfBirth | PhoneNumber    | Email                   | BankAccountNumber                 |
		| Roya      |          | 1984-04-11  | 00989123491682 | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 |
	When I press Submit button
	Then I should get 'LastNameRequiredException' exception

Scenario: Customer with invalid phoneNumber should be rejected
	Given I enter following values for new customer
		| FirstName | LastName  | DateOfBirth | PhoneNumber          | Email                   | BankAccountNumber                 |
		| Roya      | Allahyari | 1984-04-11  | 00989123491682245111 | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 |
	When I press Submit button
	Then I should get 'InvalidPhoneNumberException' exception

Scenario: Customer with null phoneNumber should be rejected
	Given I enter following values for new customer
		| FirstName | LastName  | DateOfBirth | PhoneNumber | Email                   | BankAccountNumber                 |
		| Roya      | Allahyari | 1984-04-11  |             | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 |
	When I press Submit button
	Then I should get 'PhoneNumberRequiredException' exception

Scenario: Customer with invalid email address should be rejected
	Given I enter following values for new customer
		| FirstName | LastName  | DateOfBirth | PhoneNumber    | Email             | BankAccountNumber                 |
		| Roya      | Allahyari | 1984-04-11  | 00989123491682 | allahyari3631.com | FR76 3000 6000 0112 3456 7890 189 |
	When I press Submit button
	Then I should get 'InvalidEmailException' exception

Scenario: Customer with null email address should be rejected
	Given I enter following values for new customer
		| FirstName | LastName  | DateOfBirth | PhoneNumber    | Email | BankAccountNumber                 |
		| Roya      | Allahyari | 1984-04-11  | 00989123491682 |       | FR76 3000 6000 0112 3456 7890 189 |
	When I press Submit button
	Then I should get 'EmailRequiredException' exception

Scenario: Customer with invalid bank account number should be rejected
	Given I enter following values for new customer
		| FirstName | LastName  | DateOfBirth | PhoneNumber    | Email                   | BankAccountNumber |
		| Roya      | Allahyari | 1984-04-11  | 00989123491682 | allahyari3631@gmail.com | 1234567890        |
	When I press Submit button
	Then I should get 'InvalidBankAccountNumberException' exception

Scenario: Customer with null bank account number should be rejected
	Given I enter following values for new customer
		| FirstName | LastName  | DateOfBirth | PhoneNumber    | Email                   | BankAccountNumber |
		| Roya      | Allahyari | 1984-04-11  | 00989123491682 | allahyari3631@gmail.com |                   |
	When I press Submit button
	Then I should get 'BankAccountNumberRequiredException' exception

Scenario Outline: Create Customer
	Given I enter <FirstName> and <LastName> and <DateOfBirth> and <PhoneNumber> and <Email> and <BankAccountNumber>
	When I press Submit button
	Then <Result> message should display

	Examples:
		| FirstName | LastName  | DateOfBirth | PhoneNumber          | Email                   | BankAccountNumber                 | Result                             |
		| Roya      | Allahyari | 1984-04-11  | 00989123491682       | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 | successful                         |
		| ""        | Allahyari | 1984-04-11  | 00989123491682       | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 | FirstNameRequiredException         |
		| Roya      | ""        | 1984-04-11  | 00989123491682       | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 | LastNameRequiredException          |
		| Roya      | Allahyari | 1984-04-11  | 00989123491682245111 | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 | InvalidPhoneNumberException        |
		| Roya      | Allahyari | 1984-04-11  |                      | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 | PhoneNumberRequiredException       |
		| Roya      | Allahyari | 1984-04-11  | 00989123491682       | allahyari3631.com       | FR76 3000 6000 0112 3456 7890 189 | InvalidEmailException              |
		| Roya      | Allahyari | 1984-04-11  | 00989123491682       | ""                      | FR76 3000 6000 0112 3456 7890 189 | EmailRequiredException             |
		| Roya      | Allahyari | 1984-04-11  | 00989123491682       | allahyari3631@gmail.com | 1234567890                        | InvalidBankAccountNumberException  |
		| Roya      | Allahyari | 1984-04-11  | 00989123491682       | allahyari3631@gmail.com | ""                                | BankAccountNumberRequiredException |