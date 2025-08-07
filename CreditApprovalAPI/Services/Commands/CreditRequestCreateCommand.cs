using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Commands
{
    /// <summary>
    /// Command to initiate the creation of a new credit request.
    /// </summary>
    public class CreditRequestCreateCommand : IRequest<Result<CreditRequestReadDto>>
    {
        /// <summary>
        /// Gets or sets the DTO containing the credit request data to be created.
        /// </summary>
        public CreditRequestCreateDto CreditRequest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditRequestCreateCommand"/> class.
        /// </summary>
        /// <param name="creditRequest">The credit request data transfer object.</param>
        public CreditRequestCreateCommand(CreditRequestCreateDto creditRequest)
        {
            CreditRequest = creditRequest;
        }
    }
}
