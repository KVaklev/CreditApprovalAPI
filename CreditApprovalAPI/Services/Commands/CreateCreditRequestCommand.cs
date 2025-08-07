using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Commands
{
    public class CreditRequestCreateCommand : IRequest<Result<CreditRequestReadDto>>
    {
        public CreditRequestCreateDto CreditRequest { get; set; }

        public CreditRequestCreateCommand(CreditRequestCreateDto creditRequest)
        {
            CreditRequest = creditRequest;
        }
    }
}
