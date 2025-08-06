using CreditApprovalAPI.Enums;

namespace CreditApprovalAPI.DTOs
{
    public class CreditRequestCreateDto
    {
        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public decimal MonthlyIncome { get; set; }

        public decimal CreditAmount { get; set; }

        public CreditType CreditType { get; set; } 
    }
}
