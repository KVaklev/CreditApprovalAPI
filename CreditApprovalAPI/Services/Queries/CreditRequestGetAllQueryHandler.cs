using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Queries
{
    /// <summary>
    /// Handles the <see cref="CreditRequestGetAllQuery"/> to fetch all credit requests.
    /// </summary>
    public class CreditRequestGetAllQueryHandler : IRequestHandler<CreditRequestGetAllQuery, Result<IEnumerable<CreditRequestReadDto>>>
    {
        private readonly ICreditRequestService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditRequestGetAllQueryHandler"/> class.
        /// </summary>
        /// <param name="service">The credit request service to retrieve data.</param>
        public CreditRequestGetAllQueryHandler(ICreditRequestService service)
        {
            _service = service;
        }

        /// <summary>
        /// Handles the request to retrieve all credit requests.
        /// </summary>
        /// <param name="request">The query object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The result containing a collection of credit request DTOs.</returns>
        public async Task<Result<IEnumerable<CreditRequestReadDto>>> Handle(CreditRequestGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(cancellationToken);
        }
    }
}
