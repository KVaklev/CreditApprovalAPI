using AutoMapper;
using CreditApprovalAPI.Enums;
using CreditApprovalAPI.Models;

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

        public static void CreateMap(Profile profile)
        {
            profile.CreateMap<CreditRequest, CreditRequestReadDto>();
        }
    }
}
