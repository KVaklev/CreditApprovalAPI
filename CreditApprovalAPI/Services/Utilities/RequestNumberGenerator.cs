using CreditApprovalAPI.Repository;

namespace CreditApprovalAPI.Services.Utilities
{
    public static class RequestNumberGenerator
    {
        public static async Task<string> GenerateRequestNumberAsync(ICreditRequestRepository repository, CancellationToken cancellationToken)
        {
            var datePart = DateTime.UtcNow.ToString("yyyyMMdd");

            var count = await repository.CountTodayRequestsAsync(DateTime.UtcNow, cancellationToken);

            return $"CRE-{datePart}-{(count + 1).ToString("D4")}";
        }
    }
}
