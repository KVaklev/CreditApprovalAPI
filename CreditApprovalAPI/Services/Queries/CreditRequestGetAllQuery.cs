using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Queries
{
    /// <summary>
    /// Query to retrieve credit requests.
    /// </summary>
    public class CreditRequestGetAllQuery : IRequest<Result<IEnumerable<CreditRequestReadDto>>>
    {
        public CreditRequestFilterDto? Filter { get; }

        public CreditRequestGetAllQuery(CreditRequestFilterDto? filter = null)
        {
            Filter = filter;
        }
    }
}
