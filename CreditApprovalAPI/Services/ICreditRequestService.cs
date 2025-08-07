using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;

namespace CreditApprovalAPI.Services
{
    public interface ICreditRequestService
    {
        Task<Result<IEnumerable<CreditRequestReadDto>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Result<CreditRequestReadDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Result<CreditRequestReadDto>> CreateAsync(CreditRequestCreateDto dto, CancellationToken cancellationToken);
        Task<Result<CreditRequestReadDto>> ReviewAsync(CreditRequestReviewDto dto, CancellationToken cancellationToken);
    }
}
