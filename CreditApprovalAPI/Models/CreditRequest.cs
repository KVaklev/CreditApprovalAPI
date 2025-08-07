using CreditApprovalAPI.Enums;

namespace CreditApprovalAPI.Models
{
    /// <summary>
    /// Represents a credit request submitted by a user.
    /// This is the main entity stored in the database.
    /// </summary>
    public class CreditRequest
    {
        /// <summary>
        /// Unique identifier for the credit request.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Unique request number generated for tracking.
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
        /// Monthly income declared by the applicant.
        /// </summary>
        public decimal MonthlyIncome { get; set; }

        /// <summary>
        /// Requested credit amount.
        /// </summary>
        public decimal CreditAmount { get; set; }

        /// <summary>
        /// Type of credit being requested (e.g., Mortgage, Auto, Personal).
        /// </summary>
        public CreditType CreditType { get; set; } = CreditType.ToBeConfirmed;

        /// <summary>
        /// Current status of the credit request.
        /// </summary>
        public CreditStatus Status { get; set; } = CreditStatus.Pending_Review;

        /// <summary>
        /// Name of the reviewer who approved/rejected the request.
        /// </summary>
        public string ReviewerName { get; set; }

        /// <summary>
        /// Date when the request was reviewed.
        /// </summary>
        public DateTime? ReviewDate { get; set; }

        /// <summary>
        /// Date when the credit request was created.
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
