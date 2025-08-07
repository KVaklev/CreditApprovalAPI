using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;

namespace CreditApprovalAPI.Services
{
    /// <summary>
    /// Defines the contract for handling credit request business operations.
    /// </summary>
    public interface ICreditRequestService
    {
        /// <summary>
        /// Retrieves all existing credit requests.
        /// </summary>
        /// <returns>A list of credit request read DTOs.</returns>
        Task<Result<IEnumerable<CreditRequestReadDto>>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a specific credit request by its ID.
        /// </summary>
        /// <param name="id">The identifier of the credit request.</param>
        /// <returns>The corresponding credit request read DTO, or null if not found.</returns>
        Task<Result<CreditRequestReadDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new credit request.
        /// </summary>
        /// <param name="dto">The credit request creation data.</param>
        /// <returns>The created credit request as a read DTO.</returns>
        Task<Result<CreditRequestReadDto>> CreateAsync(CreditRequestCreateDto dto, CancellationToken cancellationToken);

        /// <summary>
        /// Reviews a credit request by applying approval or rejection logic.
        /// </summary>
        /// <param name="dto">The DTO containing the review decision and reviewer details.</param>       
        /// <returns>
        /// A result object containing either the updated credit request read DTO upon success,
        /// or error details if the operation fails (e.g., not found or invalid state).
        /// </returns>
        Task<Result<CreditRequestReadDto>> ReviewAsync(CreditRequestReviewDto dto, CancellationToken cancellationToken);
    }
}
