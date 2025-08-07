namespace CreditApprovalAPI.Enums
{
    /// <summary>
    /// Defines the type of credit being requested.
    /// </summary>
    public enum CreditType
    {
        /// <summary>
        /// The type of credit has not been confirmed yet.
        /// </summary>
        ToBeConfirmed = 0,

        /// <summary>
        /// A mortgage loan for property financing.
        /// </summary>
        Mortgage = 1,

        /// <summary>
        /// An auto loan for vehicle purchase.
        /// </summary>
        Auto = 2,

        /// <summary>
        /// A personal loan for general use.
        /// </summary>
        Personal = 3
    }
}
