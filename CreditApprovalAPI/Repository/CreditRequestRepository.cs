using CreditApprovalAPI.Data;
using CreditApprovalAPI.Models;
using CreditApprovalAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace CreditApprovalAPI.Repositories
{
    public class CreditRequestRepository : ICreditRequestRepository
    {
        private readonly CreditDbContext _context;

        public CreditRequestRepository(CreditDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CreditRequest>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.CreditRequests.ToListAsync(cancellationToken);
        }

        public async Task<CreditRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.CreditRequests.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public async Task AddAsync(CreditRequest creditRequest, CancellationToken cancellationToken)
        {
            await _context.CreditRequests.AddAsync(creditRequest, cancellationToken);
        }

        public async Task<int> CountTodayRequestsAsync(DateTime today, CancellationToken cancellationToken)
        {
            return await _context.CreditRequests
                .CountAsync(r => r.CreatedDate.Date == today.Date, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }       
    }
}
