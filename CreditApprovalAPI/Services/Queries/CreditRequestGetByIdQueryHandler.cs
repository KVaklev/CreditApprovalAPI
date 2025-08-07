using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Queries
{
    /// <summary>
    /// Handles the <see cref="CreditRequestGetByIdQuery"/> to fetch a credit request by ID.
    /// </summary>
    public class CreditRequestGetByIdQueryHandler : IRequestHandler<CreditRequestGetByIdQuery, Result<CreditRequestReadDto>>
    {
        private readonly ICreditRequestService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditRequestGetByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="service">The credit request service to retrieve the data.</param>
        public CreditRequestGetByIdQueryHandler(ICreditRequestService service)
        {
            _service = service;
        }

        /// <summary>
        /// Handles the request to retrieve a credit request by its ID.
        /// </summary>
        /// <param name="request">The query containing the ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The result containing the credit request DTO or failure if not found.</returns>
        public async Task<Result<CreditRequestReadDto>> Handle(CreditRequestGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
