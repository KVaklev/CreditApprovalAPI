using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Queries
{
    public class CreditRequestGetByIdQueryHandler : IRequestHandler<CreditRequestGetByIdQuery, Result<CreditRequestReadDto>>
    {
        private readonly ICreditRequestService _service;

        public CreditRequestGetByIdQueryHandler(ICreditRequestService service)
        {
            _service = service;
        }

        public async Task<Result<CreditRequestReadDto>> Handle(CreditRequestGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
