using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Commands
{
    /// <summary>
    /// Handles the <see cref="CreditRequestReviewCommand"/> to review and update a credit request's status.
    /// </summary>
    public class CreditRequestReviewCommandHandler : IRequestHandler<CreditRequestReviewCommand, Result<CreditRequestReadDto>>
    {
        private readonly ICreditRequestService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditRequestReviewCommandHandler"/> class.
        /// </summary>
        /// <param name="service">The credit request service to process the review.</param>
        public CreditRequestReviewCommandHandler(ICreditRequestService service)
        {
            _service = service;
        }

        /// <summary>
        /// Handles the command to review a credit request.
        /// </summary>
        /// <param name="request">The review command containing the ID and review DTO.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The result containing the updated credit request DTO.</returns>
        public async Task<Result<CreditRequestReadDto>> Handle(CreditRequestReviewCommand request, CancellationToken cancellationToken)
        {
            return await _service.ReviewAsync(request.ReviewDto, cancellationToken);
        }
    }
}
