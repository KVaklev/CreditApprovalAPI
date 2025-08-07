using CreditApprovalAPI.Models;

namespace CreditApprovalAPI.Repository
{
    /// <summary>
    /// Defines the contract for accessing and manipulating credit request data.
    /// </summary>
    public interface ICreditRequestRepository
    {
        /// <summary>
        /// Retrieves all credit requests from the database.
        /// </summary>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>A collection of all credit requests.</returns>
        Task<IEnumerable<CreditRequest>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a credit request by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the credit request.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>The matching credit request if found; otherwise, null.</returns>
        Task<CreditRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new credit request to the database context.
        /// </summary>
        /// <param name="entity">The credit request entity to add.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        Task AddAsync(CreditRequest entity, CancellationToken cancellationToken);

        /// <summary>
        /// Counts the number of credit requests created on the specified date.
        /// </summary>
        /// <param name="date">The date to filter requests by (typically today).</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>The number of credit requests created on the given date.</returns>
        Task<int> CountTodayRequestsAsync(DateTime date, CancellationToken cancellationToken);

        /// <summary>
        /// Persists all pending changes in the database context.
        /// </summary>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
