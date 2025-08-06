using CreditApprovalAPI.Enums;

namespace CreditApprovalAPI.Models
{
    public class CreditRequest
    {
        public Guid Id { get; set; }

        public string RequestNumber { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public decimal MonthlyIncome { get; set; }

        public decimal CreditAmount { get; set; }

        public CreditType CreditType { get; set; } = CreditType.ToBeConfirmed;

        public CreditStatus Status { get; set; } = CreditStatus.Pending_Review;

        public string? ApproverNamer { get; set; }

        public DateTime? ReviewDate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


    }
}
