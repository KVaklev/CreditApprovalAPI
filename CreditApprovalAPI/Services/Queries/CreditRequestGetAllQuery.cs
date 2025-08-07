using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Queries
{
    /// <summary>
    /// Query to retrieve all credit requests.
    /// </summary>
    public class CreditRequestGetAllQuery : IRequest<Result<IEnumerable<CreditRequestReadDto>>>
    {
    }
}
