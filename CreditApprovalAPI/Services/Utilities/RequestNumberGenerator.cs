
using CreditApprovalAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CreditApprovalAPI.Services.Utilities
{
    public static class RequestNumberGenerator
    {
        public static async Task<string> GenerateRequestNumberAsync(CreditDbContext context, CancellationToken cancellationToken)
        {
            var datePart = DateTime.UtcNow.ToString("yyyyMMdd");
            var count = await context.CreditRequests.CountAsync(
                r => r.CreatedDate.Date == DateTime.UtcNow.Date,
                cancellationToken
            );

            return $"CRE-{datePart}-{(count + 1).ToString("D4")}";
        }
    }
}
