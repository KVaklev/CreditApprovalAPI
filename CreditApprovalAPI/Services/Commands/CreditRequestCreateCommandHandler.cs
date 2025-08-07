using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Commands
{
    /// <summary>
    /// Handles the <see cref="CreditRequestCreateCommand"/> to create a new credit request.
    /// </summary>
    public class CreditRequestCreateCommandHandler : IRequestHandler<CreditRequestCreateCommand, Result<CreditRequestReadDto>>
    {
        private readonly ICreditRequestService _creditRequestService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditRequestCreateCommandHandler"/> class.
        /// </summary>
        /// <param name="creditRequestService">The credit request service for business logic.</param>
        public CreditRequestCreateCommandHandler(ICreditRequestService creditRequestService)
        {
            _creditRequestService = creditRequestService;
        }

        /// <summary>
        /// Handles the command to create a credit request.
        /// </summary>
        /// <param name="request">The create command containing the credit request DTO.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The result containing the created credit request DTO.</returns>
        public async Task<Result<CreditRequestReadDto>> Handle(CreditRequestCreateCommand request, CancellationToken cancellationToken)
        {
            return await _creditRequestService.CreateAsync(request.CreditRequest, cancellationToken);
        }
    }
}
