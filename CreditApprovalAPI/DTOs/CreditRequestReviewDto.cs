using AutoMapper;
using CreditApprovalAPI.Models;

namespace CreditApprovalAPI.DTOs
{
    public class CreditRequestReviewDto
    {
        public Guid Id { get; set; }

        public string ReviewerName { get; set; }

        public bool IsApproved { get; set; }

        public static void CreateMap(Profile profile)
        {
            profile.CreateMap<CreditRequestReviewDto, CreditRequest>()
                .ForMember(dest => dest.ReviewerName, opt => opt.MapFrom(src => src.ReviewerName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsApproved ? Enums.CreditStatus.Approved : Enums.CreditStatus.Rejected))
                .ForMember(dest => dest.ReviewDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForAllMembers(opt => opt.Ignore());
        }
    }
}
