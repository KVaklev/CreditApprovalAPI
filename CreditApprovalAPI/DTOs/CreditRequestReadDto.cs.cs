using CreditApprovalAPI.Enums;

namespace CreditApprovalAPI.DTOs
{    
    public class CreditRequestReadDto
    {
        public Guid Id { get; set; }

        public string RequestNumber { get; set; } 

        public string FullName { get; set; } 

        public string Email { get; set; } 

        public decimal MonthlyIncome { get; set; }

        public decimal CreditAmount { get; set; }

        public CreditType CreditType { get; set; }

        public CreditStatus Status { get; set; }

        public string? ReviewerName { get; set; }

        public DateTime? ReviewDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
