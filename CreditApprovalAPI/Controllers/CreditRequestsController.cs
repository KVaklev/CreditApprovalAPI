using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Commands;
using CreditApprovalAPI.Services.Queries;
using CreditApprovalAPI.Services.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditApprovalAPI.Controllers
{
    /// <summary>
    /// API Controller for managing credit requests, including creation, retrieval, and review operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CreditRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditRequestsController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator instance for sending commands and queries.</param>
        public CreditRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }        

        /// <summary>
        /// Creates a new credit request.
        /// </summary>
        /// <param name="dto">The DTO containing credit request details.</param>
        /// <returns>HTTP 200 with result if successful; otherwise, HTTP 400 Bad Request.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<CreditRequestReadDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreditRequestCreateDto dto)
        {
            var result = await _mediator.Send(new CreditRequestCreateCommand(dto));
            return result.isSuccess ? Ok(result) : BadRequest(result);
        }

        /// <summary>
        /// Retrieves a credit request by its unique identifier.
        /// </summary>
        /// <param name="id">The unique ID of the credit request.</param>
        /// <returns>HTTP 200 with the credit request if found; otherwise, HTTP 404 Not Found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<CreditRequestReadDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new CreditRequestGetByIdQuery(id));
            return result.isSuccess ? Ok(result) : NotFound(result);
        }

        /// <summary>
        /// Retrieves all credit requests, optionally filtered by status and credit type.
        /// </summary>
        /// <param name="filter">Filter criteria.</param>
        /// <returns>HTTP 200 with list of credit requests.</returns>
        [HttpGet("existing-requests")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<IEnumerable<CreditRequestReadDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] CreditRequestFilterDto filter)
        {
            var result = await _mediator.Send(new CreditRequestGetAllQuery(filter));
            return Ok(result);
        }

        /// <summary>
        /// Reviews a credit request by updating its status.
        /// </summary>
        /// <param name="id">The unique ID of the credit request to review.</param>
        /// <param name="dto">The DTO containing review information.</param>
        /// <returns>HTTP 200 with updated credit request if successful; otherwise, HTTP 400 Bad Request.</returns>
        [HttpPost("{id}/review")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<CreditRequestReadDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Review(Guid id, [FromBody] CreditRequestReviewDto dto)
        {
            var result = await _mediator.Send(new CreditRequestReviewCommand(id, dto));
            return result.isSuccess ? Ok(result) : BadRequest(result);
        }        
    }
}
