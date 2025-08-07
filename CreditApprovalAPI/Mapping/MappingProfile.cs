using AutoMapper;
using CreditApprovalAPI.DTOs;

namespace CreditApprovalAPI.Mapping
{
    /// <summary>
    /// Configures AutoMapper mappings for DTOs and domain models.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class 
        /// and registers all DTO-to-entity and entity-to-DTO mappings.
        /// </summary>
        public MappingProfile()
        {            
            CreditRequestCreateDto.CreateMap(this);
            CreditRequestReadDto.CreateMap(this);
            CreditRequestReviewDto.CreateMap(this);
        }
    }
}
