using CreditApprovalAPI.Models;

namespace CreditApprovalAPI.Repository
{
    public interface ICreditRequestRepository
    {
        Task<IEnumerable<CreditRequest>> GetAllAsync(CancellationToken cancellationToken);
        Task<CreditRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(CreditRequest entity, CancellationToken cancellationToken);
        Task<int> CountTodayRequestsAsync(DateTime date, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);

    }

}
