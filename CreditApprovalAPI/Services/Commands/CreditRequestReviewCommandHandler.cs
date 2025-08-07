using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Commands
{
    public class CreditRequestReviewCommandHandler : IRequestHandler<CreditRequestReviewCommand, Result<CreditRequestReadDto>>
    {
        private readonly ICreditRequestService _service;

        public CreditRequestReviewCommandHandler(ICreditRequestService service)
        {
            _service = service;
        }

        public async Task<Result<CreditRequestReadDto>> Handle(CreditRequestReviewCommand request, CancellationToken cancellationToken)
        {
            return await _service.ReviewAsync( request.ReviewDto, cancellationToken);
        }
    }
}
