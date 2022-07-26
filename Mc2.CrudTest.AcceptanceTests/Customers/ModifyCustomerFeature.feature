Feature: ModifyCustomerFeature
As a user,
In order to mange customer,
I need to be able edit customer

@Customer
Scenario: As a user I should be able to modify customer info
	Given There is a customer with following values
		| FirstName | LastName  | DateOfBirth | PhoneNumber   | Email                   | BankAccountNumber                 |
		| Roya      | Allahyari | 1984-04-11  | +989123491682 | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 |
	And I select customer to edit
	And I set firstName to 'amir'
	And I set lastName to 'alahyari'
	And I set DateOfBirth to '1994-03-13'
	And I set PhoneNumber to '+989125794172'
	And I set Email to 'allahyari.amir@yahoo.com'
	And I set BankAccountNumber to 'GB82 WEST 1234 5698 7654 32'
	When I press Submit button
	Then I should not get any exception
	And customer info should be changed to following values
		| FirstName | LastName | DateOfBirth | PhoneNumber   | Email                    | BankAccountNumber           |
		| amir      | alahyari | 1994-03-13  | +989125794172 | allahyari.amir@yahoo.com | GB82 WEST 1234 5698 7654 32 |

Scenario: As a user I should not be able to modify customer info to exist customer with same firstName, lastName, DateOfBirth
	Given There is customers with following values
		| FirstName | LastName  | DateOfBirth | PhoneNumber   | Email                    | BankAccountNumber                 |
		| Roya      | Allahyari | 1984-04-11  | +989125794172 | allahyari3631@gmail.com  | FR76 3000 6000 0112 3456 7890 189 |
		| Amir      | Allahyari | 1994-03-13  | +989125794172 | allahyari.amir@yahoo.com | GB82 WEST 1234 5698 7654 32       |
	And I select customer with firstName 'Amir' lastName 'Allahyair' dateofBirth '1994-03-13' to edit
	And I set firstName to 'Roya'
	And I set lastName to 'Allahyari'
	And I set DateOfBirth to '1984-04-11'
	When I press Submit button
	Then I should get 'DuplicateCustomerException' exception

Scenario: As a user I should not be able to modify phoneNumber of customer to invalid phoneNumber
	Given There is a customer with following values
		| FirstName | LastName  | DateOfBirth | PhoneNumber   | Email                   | BankAccountNumber                 |
		| Roya      | Allahyari | 1984-04-11  | +989125794172 | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 |
	And I select customer to edit
	And I set phoneNumber to '9811111111111111111111'
	When I press Submit button
	Then I should get 'InvalidPhoneNumberException' exception

Scenario: As a user I should not be able to modify email of customer to invalid email
	Given There is a customer with following values
		| FirstName | LastName  | DateOfBirth | PhoneNumber   | Email                   | BankAccountNumber                 |
		| Roya      | Allahyari | 1984-04-11  | +989123491682 | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 |
	And I select customer to edit
	And I set Email to 'allahyari3631'
	When I press Submit button
	Then I should get 'InvalidEmailException' exception

Scenario: As a user I should not be able to modify BankAccountNumber of customer to invalid BankAccountNumber
	Given There is a customer with following values
		| FirstName | LastName  | DateOfBirth | PhoneNumber   | Email                   | BankAccountNumber                 |
		| Roya      | Allahyari | 1984-04-11  | +989123491682 | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 |
	And I select customer to edit
	And I set BankAccountNumber to 'FR7630006000011234567890189'
	When I press Submit button
	Then I should get 'InvalidBankAccountNumberException' exception