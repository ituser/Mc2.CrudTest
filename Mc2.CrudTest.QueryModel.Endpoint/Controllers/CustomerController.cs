using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mc2.CrudTest.QueryModel.Services.Contracts.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.QueryModel.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerQueryService customerQueryService;

        public CustomerController(ICustomerQueryService customerQueryService)
        {
            this.customerQueryService = customerQueryService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<CustomerQueryDTO>>> GetAll()
        {
            var customers = await customerQueryService.GetCustomers();

            return Ok(customers);
        }

        [HttpGet]
        public async Task<ActionResult<IList<CustomerQueryDTO>>> Get(Guid customerId)
        {
            var customers = await customerQueryService.GetCustomer(customerId);

            return Ok(customers);
        }
    }
}