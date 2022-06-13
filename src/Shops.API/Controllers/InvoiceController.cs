using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shops.Application.Dtos;
using Shops.Application.Features.Commands.Invoices.CreateInvoice;
using Shops.Application.Features.Queries.Invoices.GetAllInvoices;
using Shops.Application.Features.Queries.Invoices.GetByIdInvoice;

namespace Shops.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private IMediator _mediator;

        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(IList<InvoiceListDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(Guid id)
        {
            return Ok(await _mediator.Send(new GetByIdInvoiceRequest(id)));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<InvoiceListDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllInvoicesResponse()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateInvoiceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromQuery] CreateInvoiceRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}