using AutoMapper;
using CreditApprovalAPI.DTOs;

namespace CreditApprovalAPI.Mapping
{
    public class MappingProfile : Profile
    {       
        public MappingProfile()
        {
            CreditRequestCreateDto.CreateMap(this);
            CreditRequestReadDto.CreateMap(this);
            CreditRequestReviewDto.CreateMap(this);
        }
    }
}
