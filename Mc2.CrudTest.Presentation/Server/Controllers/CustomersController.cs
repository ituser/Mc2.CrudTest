using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mc2.CrudTest.Application.Contracts.Customers;
using Mc2.CrudTest.FacadeService.Contracts.Customers;
using Mc2.CrudTest.QueryModel.Services.Contracts.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerFacadeService customerFacadeService;

        private readonly ICustomerQueryService customerQueryService;

        public CustomersController(ICustomerFacadeService customerFacadeService, ICustomerQueryService customerQueryService)
        {
            this.customerFacadeService = customerFacadeService;
            this.customerQueryService = customerQueryService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<CustomerQueryDTO>>> GetAll()
        {
            var customers = await customerQueryService.GetCustomers();

            return Ok(customers);
        }

        [HttpPost]
        public IActionResult CreateCustomer(CreateCustomerCommand command)
        {
            customerFacadeService.CreateCustomer(command);

            return Ok();
        }

        [HttpPut]
        public IActionResult EditCustomer(ModifyCustomerCommand command)
        {
            customerFacadeService.ModifyCustomer(command);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(Guid customerId)
        {
            customerFacadeService.RemoveCustomer(customerId);

            return Ok();
        }
    }
}