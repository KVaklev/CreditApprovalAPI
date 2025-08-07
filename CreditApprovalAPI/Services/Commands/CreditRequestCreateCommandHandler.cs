using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Commands
{
    public class CreditRequestCreateCommandHandler : IRequestHandler<CreditRequestCreateCommand, Result<CreditRequestReadDto>>
    {
        private readonly ICreditRequestService _creditRequestService;

        public CreditRequestCreateCommandHandler(ICreditRequestService creditRequestService)
        {
            _creditRequestService = creditRequestService;
        }

        public async Task<Result<CreditRequestReadDto>> Handle(CreditRequestCreateCommand request, CancellationToken cancellationToken)
        {
            return await _creditRequestService.CreateAsync(request.CreditRequest, cancellationToken);
        }
    }
}
