using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shops.Application.Dtos;
using Shops.Application.Features.Queries.CurrentAccountTypes;

namespace Shops.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentTypeControllerController : ControllerBase
    {
        private IMediator _mediator;

        public CurrentTypeControllerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<CurrentAccountTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllCurrentAccountTypeResponse()));
        }
    }
}