using CreditApprovalAPI.Repository;

namespace CreditApprovalAPI.Services.Utilities
{
    /// <summary>
    /// Provides utility methods for generating unique request numbers for credit requests.
    /// </summary>
    public static class RequestNumberGenerator
    {
        /// <summary>
        /// Generates a unique request number in the format "CRE-yyyyMMdd-XXXX" where XXXX is a zero-padded count of today's requests plus one.
        /// </summary>
        /// <param name="repository">The repository to count existing requests.</param>
        /// <param name="cancellationToken">A cancellation token to observe while generating the request number.</param>
        /// <returns>A unique request number string.</returns>
        public static async Task<string> GenerateRequestNumberAsync(ICreditRequestRepository repository, CancellationToken cancellationToken)
        {
            var datePart = DateTime.UtcNow.ToString("yyyyMMdd");

            var count = await repository.CountTodayRequestsAsync(DateTime.UtcNow, cancellationToken);

            return $"CRE-{datePart}-{(count + 1).ToString("D4")}";
        }
    }
}
