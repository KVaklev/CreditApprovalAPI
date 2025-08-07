namespace CreditApprovalAPI.Enums
{
    /// <summary>
    /// Represents the status of a credit request throughout its lifecycle.
    /// </summary>
    public enum CreditStatus
    {
        /// <summary>
        /// Indicates the credit request is pending review.
        /// </summary>
        Pending_Review = 0,

        /// <summary>
        /// Indicates the credit request has been approved.
        /// </summary>
        Approved = 1,

        /// <summary>
        /// Indicates the credit request has been rejected.
        /// </summary>
        Rejected = 2
    }
}
