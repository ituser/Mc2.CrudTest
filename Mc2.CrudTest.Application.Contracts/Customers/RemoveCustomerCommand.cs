using System;
using MediatR;

namespace Mc2.CrudTest.Application.Contracts.Customers
{
    public class RemoveCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
}