using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Commands;
using CreditApprovalAPI.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditApprovalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreditRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreditRequestCreateDto dto)
        {
            var result = await _mediator.Send(new CreditRequestCreateCommand(dto));
            return result.isSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new CreditRequestGetByIdQuery(id));
            return result.isSuccess ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new CreditRequestGetAllQuery());
            return Ok(result);
        }

        [HttpPost("{id}/review")]
        public async Task<IActionResult> Review(Guid id, [FromBody] CreditRequestReviewDto dto)
        {
            var result = await _mediator.Send(new CreditRequestReviewCommand(id, dto));
            return result.isSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
