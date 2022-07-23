﻿using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers.Exceptions
{
    public class DuplicateEmailException : BusinessException
    {
        public override string Message => "Email is exist!";
    }
}