using AutoMapper;
using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Models;
using CreditApprovalAPI.Enums;

namespace CreditApprovalAPI.Mapping
{
    public class CreditRequestProfile : Profile
    {
        public CreditRequestProfile()
        {
            // CREATE mapping (from CreateDto to Entity)
            CreateMap<CreditRequestCreateDto, CreditRequest>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => CreditStatus.Pending_Review))
                .ForMember(dest => dest.RequestNumber, opt => opt.Ignore()) 
                .ForMember(dest => dest.Id, opt => opt.Ignore())            
                .ForMember(dest => dest.ReviewerName, opt => opt.Ignore())
                .ForMember(dest => dest.ReviewDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());

           

            
        }
    }
}
