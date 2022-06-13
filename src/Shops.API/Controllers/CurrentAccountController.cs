using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shops.Application.Dtos;
using Shops.Application.Features.Commands.CurrentAccounts.CreateCurrAcc;
using Shops.Application.Features.Queries.CurrentAccounts.GetAllCurrentAccounts;
using Shops.Application.Features.Queries.CurrentAccounts.GetByIdCurrentAccount;

namespace Shops.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentAccountController : ControllerBase
    {
        private IMediator _mediator;

        public CurrentAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateCurrAccResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromQuery] CreateCurrAccRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CurrentAccountDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrentAccount(Guid id)
        {
            return Ok(await _mediator.Send(new GetByIdCurrentAccountRequest(id)));
        }

        [HttpGet(Name = "GelCurrentAccounts")]
        [ProducesResponseType(typeof(IList<CurrentAccountDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllCurrentAccountResponse()));
        }
    }
}