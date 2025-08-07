using CreditApprovalAPI.Enums;
using System.Text.Json.Serialization;

namespace CreditApprovalAPI.DTOs
{
    /// <summary>
    /// DTO used to filter credit requests by status and credit type.
    /// </summary>
    public class CreditRequestFilterDto
    {
        /// <summary>
        /// The status to filter by (e.g., Approved, Rejected, Pending_Review).
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CreditStatus? Status { get; set; }

        /// <summary>
        /// The type of credit to filter by (e.g., Personal, Mortgage, Auto).
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CreditType? CreditType { get; set; }
    }
}
