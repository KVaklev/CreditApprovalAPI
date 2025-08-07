using AutoMapper;
using CreditApprovalAPI.Enums;
using CreditApprovalAPI.Models;
using System.Text.Json.Serialization;

namespace CreditApprovalAPI.DTOs
{
    /// <summary>
    /// DTO for creating a new credit request.
    /// </summary>
    public class CreditRequestCreateDto
    {
        /// <summary>
        /// Full name of the applicant.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Email address of the applicant.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Applicant's monthly income.
        /// </summary>
        public decimal MonthlyIncome { get; set; }

        /// <summary>
        /// Requested credit amount.
        /// </summary>
        public decimal CreditAmount { get; set; }

        /// <summary>
        /// Type of credit requested (e.g., Auto, Mortgage, Personal).
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CreditType CreditType { get; set; }        


        /// <summary>
        /// Maps this DTO to the <see cref="CreditRequest"/> domain model.
        /// </summary>
        /// <param name="profile">AutoMapper profile to configure mapping.</param>
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
