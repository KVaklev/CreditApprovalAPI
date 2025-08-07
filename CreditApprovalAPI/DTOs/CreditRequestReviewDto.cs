using AutoMapper;
using CreditApprovalAPI.Models;

namespace CreditApprovalAPI.DTOs
{
    /// <summary>
    /// DTO used to submit a review (approval/rejection) for a credit request.
    /// </summary>
    public class CreditRequestReviewDto
    {
        /// <summary>
        /// Identifier of the credit request to review.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the reviewer.
        /// </summary>
        public string ReviewerName { get; set; }

        /// <summary>
        /// Flag indicating whether the request is approved.
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Maps this DTO to the <see cref="CreditRequest"/> domain model.
        /// Only fields relevant for review are mapped.
        /// </summary>
        /// <param name="profile">AutoMapper profile to configure mapping.</param>
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
