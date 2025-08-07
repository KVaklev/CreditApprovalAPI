using CreditApprovalAPI.Data;
using CreditApprovalAPI.Models;
using CreditApprovalAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace CreditApprovalAPI.Repositories
{
    /// <summary>
    /// Implements data access operations for credit requests using Entity Framework Core.
    /// </summary>
    public class CreditRequestRepository : ICreditRequestRepository
    {
        private readonly CreditDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditRequestRepository"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public CreditRequestRepository(CreditDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all credit requests from the database.
        /// </summary>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>A collection of all credit requests.</returns>
        public async Task<IEnumerable<CreditRequest>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.CreditRequests.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a credit request by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the credit request.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>The matching credit request if found; otherwise, null.</returns>
        public async Task<CreditRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.CreditRequests.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        /// <summary>
        /// Adds a new credit request to the database context.
        /// </summary>
        /// <param name="creditRequest">The credit request entity to add.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        public async Task AddAsync(CreditRequest creditRequest, CancellationToken cancellationToken)
        {
            await _context.CreditRequests.AddAsync(creditRequest, cancellationToken);
        }

        /// <summary>
        /// Counts the number of credit requests created on the specified date.
        /// </summary>
        /// <param name="today">The date to filter requests by.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>The number of credit requests created on the given date.</returns>
        public async Task<int> CountTodayRequestsAsync(DateTime today, CancellationToken cancellationToken)
        {
            return await _context.CreditRequests
                .CountAsync(r => r.CreatedDate.Date == today.Date, cancellationToken);
        }

        /// <summary>
        /// Persists all pending changes in the database context.
        /// </summary>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
