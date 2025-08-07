using AutoMapper;
using CreditApprovalAPI.Enums;
using CreditApprovalAPI.Models;

namespace CreditApprovalAPI.DTOs
{   
    /// <summary>
     /// DTO for reading/displaying a credit request.
     /// </summary>
    public class CreditRequestReadDto
    {
        /// <summary>
        /// Unique identifier of the credit request.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Unique request number.
        /// </summary>
        public string RequestNumber { get; set; }

        /// <summary>
        /// Full name of the applicant.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Email address of the applicant.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Monthly income of the applicant.
        /// </summary>
        public decimal MonthlyIncome { get; set; }

        /// <summary>
        /// Requested credit amount.
        /// </summary>
        public decimal CreditAmount { get; set; }

        /// <summary>
        /// Type of credit requested.
        /// </summary>
        public CreditType CreditType { get; set; }

        /// <summary>
        /// Current status of the request.
        /// </summary>
        public CreditStatus Status { get; set; }

        /// <summary>
        /// Reviewer who approved/rejected the request.
        /// </summary>
        public string ReviewerName { get; set; }

        /// <summary>
        /// Date the request was reviewed.
        /// </summary>
        public DateTime? ReviewDate { get; set; }

        /// <summary>
        /// Date the request was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Maps this DTO from the <see cref="CreditRequest"/> domain model.
        /// </summary>
        /// <param name="profile">AutoMapper profile to configure mapping.</param>
        public static void CreateMap(Profile profile)
        {
            profile.CreateMap<CreditRequest, CreditRequestReadDto>();
        }
    }
}
