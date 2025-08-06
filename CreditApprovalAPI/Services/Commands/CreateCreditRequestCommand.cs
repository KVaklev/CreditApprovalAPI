using CreditApprovalAPI.DTOs;
using MediatR;

namespace CreditApprovalAPI.Services.Commands
{
    public class CreditRequestCreateCommand : IRequest<CreditRequestReadDto>
    {
        public CreditRequestCreateDto CreditRequest { get; set; }
    }
}
