using CreditApprovalAPI.Models;

namespace CreditApprovalAPI.Repository
{
    public interface ICreditRequestRepository
    {
        Task<CreditRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<CreditRequest>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(CreditRequest request, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> CountTodayRequestsAsync(DateTime today, CancellationToken cancellationToken);
    }
}
