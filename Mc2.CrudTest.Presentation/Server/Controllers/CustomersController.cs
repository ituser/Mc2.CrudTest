using System;
using Mc2.CrudTest.Application.Contracts.Customers;
using Mc2.CrudTest.FacadeService.Contracts.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerFacadeService customerFacadeService;

        public CustomersController(ICustomerFacadeService customerFacadeService)
        {
            this.customerFacadeService = customerFacadeService;
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