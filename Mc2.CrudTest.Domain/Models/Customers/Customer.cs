using System;
using Mc2.CrudTest.Domain.Contracts.Events.Customers;
using Mc2.CrudTest.Domain.Models.Customers.DomainServices;
using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers
{
    public class Customer : AggregateRoot<Guid>
    {
        public Customer(
            FirstName firstName,
            LastName lastName,
            DateTime dateOfBirth,
            PhoneNumber phoneNumber,
            Email email,
            BankAccountNumber bankAccountNumber,
            IDuplicateCustomerDomainService customerDomainService,
            IDuplicateCustomerEmailDomainService customerEmailDomainService)
        {
            CheckCustomerIsNotExist(firstName.Value, lastName.Value, dateOfBirth, customerDomainService);

            CheckCustomerEmailIsNotExist(email.Value, customerEmailDomainService);

            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;

            PublishEvent(new CustomerCreatedEvent(Id,
                                                  FirstName.Value,
                                                  LastName.Value,
                                                  DateOfBirth,
                                                  Email.Value,
                                                  PhoneNumber.NationalNumber,
                                                  phoneNumber.CountryCode,
                                                  BankAccountNumber.Value,
                                                  CreateDateTime));
        }

        private Customer()
        {
        }

        public FirstName FirstName { get; set; }

        public LastName LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Email Email { get; set; }

        public PhoneNumber PhoneNumber { get; set; }

        public BankAccountNumber BankAccountNumber { get; set; }

        public void Modify(
            FirstName firstName,
            LastName lastName,
            DateTime dateOfBirth,
            PhoneNumber phoneNumber,
            Email email,
            BankAccountNumber bankAccountNumber,
            IDuplicateCustomerDomainService customerDomainService,
            IDuplicateCustomerEmailDomainService customerEmailDomainService)
        {
            CheckCustomerIsNotExistInUpdate(Id, firstName.Value, lastName.Value, dateOfBirth, customerDomainService);

            CheckCustomerEmailIsNotExistInUpdate(Id, email.Value, customerEmailDomainService);

            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
            ModifiedDateTime = DateTime.Now;

            PublishEvent(new CustomerModifiedEvent(Id,
                                                   FirstName.Value,
                                                   LastName.Value,
                                                   DateOfBirth,
                                                   Email.Value,
                                                   PhoneNumber.NationalNumber,
                                                   phoneNumber.CountryCode,
                                                   BankAccountNumber.Value,
                                                   ModifiedDateTime.Value));
        }

        public void Remove()
        {
            MarkAsRemove();

            PublishEvent(new CustomerRemovedEvent(Id, DeletedDateTime.Value));
        }

        private static void CheckCustomerIsNotExist(string firstName, string lastName, DateTime dateOfBirth, IDuplicateCustomerDomainService customerDomainService)
        {
            var isCustomerExist = customerDomainService.IsCustomerExist(firstName, lastName, dateOfBirth);
            if (isCustomerExist)
            {
                throw new DuplicateCustomerException();
            }
        }

        private static void CheckCustomerIsNotExistInUpdate(Guid id, string firstName, string lastName, DateTime dateOfBirth, IDuplicateCustomerDomainService customerDomainService)
        {
            var isCustomerExist = customerDomainService.IsCustomerExist(id, firstName, lastName, dateOfBirth);
            if (isCustomerExist)
            {
                throw new DuplicateCustomerException();
            }
        }

        private void CheckCustomerEmailIsNotExist(string email, IDuplicateCustomerEmailDomainService duplicateCustomerEmailDomainService)
        {
            var isEmailExist = duplicateCustomerEmailDomainService.IsEmailExist(email);
            if (isEmailExist)
            {
                throw new DuplicateEmailException();
            }
        }

        private void CheckCustomerEmailIsNotExistInUpdate(Guid id, string email, IDuplicateCustomerEmailDomainService duplicateCustomerEmailDomainService)
        {
            var isEmailExist = duplicateCustomerEmailDomainService.IsEmailExist(id, email);
            if (isEmailExist)
            {
                throw new DuplicateCustomerException();
            }
        }
    }
}