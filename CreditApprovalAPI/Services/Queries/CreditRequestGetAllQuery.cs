using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Queries
{
    public class CreditRequestGetAllQuery : IRequest<Result<IEnumerable<CreditRequestReadDto>>>
    {
    }
}
