Feature: DeleteCustomerFeature
As a user,
In order to mange customer,
I need to be able delete customer

@Customer
Scenario: As a user I should be able to delete customer
	Given There is a customer with following values
		| FirstName | LastName  | DateOfBirth | PhoneNumber   | Email                   | BankAccountNumber                 |
		| Roya      | Allahyari | 1984-04-11  | +989123491682 | allahyari3631@gmail.com | FR76 3000 6000 0112 3456 7890 189 |
	And I select customer to delete
	When I press Submit button
	Then I should not get any exception
	And The customer should removed from customers list

Scenario: As a user I should not be able to modify phoneNumber of customer to invalid phoneNumber
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
	And I select customer with firstName 'Amir' lastName 'Allahyair' dateofBirth '1994-03-13' to delete
	And I press Submit button
	And I should not get any exception
	And The customer should removed from customers list
	When I select customer with firstName 'Amir' lastName 'Allahyair' dateofBirth '1994-03-13' to edit
	And I set firstName to 'Roya'
	And I set lastName to 'Allahyari'
	And I set DateOfBirth to '1984-04-11'
	When I press Submit button
	Then I should not get any exception