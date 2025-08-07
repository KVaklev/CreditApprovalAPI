using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Commands
{
    public class CreditRequestReviewCommand : IRequest<Result<CreditRequestReadDto>>
    {
        public Guid Id { get; set; }
        public CreditRequestReviewDto ReviewDto { get; set; }

        public CreditRequestReviewCommand(Guid id, CreditRequestReviewDto reviewDto)
        {
            Id = id;
            ReviewDto = reviewDto;
        }
    }
}
