using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Queries
{
    public class CreditRequestGetAllQueryHandler : IRequestHandler<CreditRequestGetAllQuery, Result<IEnumerable<CreditRequestReadDto>>>
    {
        private readonly ICreditRequestService _service;

        public CreditRequestGetAllQueryHandler(ICreditRequestService service)
        {
            _service = service;
        }

        public async Task<Result<IEnumerable<CreditRequestReadDto>>> Handle(CreditRequestGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(cancellationToken);
        }
    }
}
