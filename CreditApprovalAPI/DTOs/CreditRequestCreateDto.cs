using AutoMapper;
using CreditApprovalAPI.Enums;
using CreditApprovalAPI.Models;

namespace CreditApprovalAPI.DTOs
{
    public class CreditRequestCreateDto
    {
        public string FullName { get; set; } 

        public string Email { get; set; } 

        public decimal MonthlyIncome { get; set; }

        public decimal CreditAmount { get; set; }

        public CreditType CreditType { get; set; }

        public static void CreateMap(Profile profile)
        {
            profile.CreateMap<CreditRequestCreateDto, CreditRequest>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => CreditStatus.Pending_Review))
                .ForMember(dest => dest.RequestNumber, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ReviewerName, opt => opt.Ignore())
                .ForMember(dest => dest.ReviewDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(CreditRequestCreateDto => DateTime.UtcNow));
        }
    }
}
