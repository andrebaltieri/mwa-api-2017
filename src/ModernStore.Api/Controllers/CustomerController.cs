using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Repositories;
using ModerStore.Infra.Transactions;

namespace ModernStore.Api.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly CustomerCommandHandler _handler;
        private readonly IUow _uow;
        public CustomerController(CustomerCommandHandler handler, IUow _uow) : base(_uow)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/customers")]
        public IActionResult Post([FromBody] RegisterCustomerCommand command)
        {
            _handler.Handle(command);
            return Ok(command);
        }
    }
}
