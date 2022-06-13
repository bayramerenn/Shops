using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shops.Application.Dtos;
using Shops.Application.Features.Queries.Discounts.GetAllDiscounts;

namespace Shops.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<DiscountDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllDiscountsResponse()));
        }
    }
}