using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Commands
{
    /// <summary>
    /// Command to initiate the review process for an existing credit request.
    /// </summary>
    public class CreditRequestReviewCommand : IRequest<Result<CreditRequestReadDto>>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the credit request to be reviewed.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the DTO containing the review decision and reviewer details.
        /// </summary>
        public CreditRequestReviewDto ReviewDto { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditRequestReviewCommand"/> class.
        /// </summary>
        /// <param name="id">The ID of the credit request to review.</param>
        /// <param name="reviewDto">The review data transfer object.</param>
        public CreditRequestReviewCommand(Guid id, CreditRequestReviewDto reviewDto)
        {
            Id = id;
            ReviewDto = reviewDto;
        }
    }
}
