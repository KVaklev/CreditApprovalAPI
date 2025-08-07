namespace CreditApprovalAPI.Services.Utilities
{
    /// <summary>
    /// Represents the outcome of an operation, including success status, optional message, and optional data.
    /// </summary>
    /// <typeparam name="T">The type of data returned in case of success.</typeparam>
    public class Result<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether the operation was successful.
        /// </summary>
        public bool isSuccess { get; set; }

        /// <summary>
        /// Gets or sets an optional message, typically used for errors or informational text.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets the data returned by the operation if successful.
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Creates a successful result wrapping the specified data and optional message.
        /// </summary>
        /// <param name="data">The data to return.</param>
        /// <param name="message">An optional informational message.</param>
        /// <returns>A successful <see cref="Result{T}"/> instance.</returns>
        public static Result<T> Ok(T data, string? message = null)
            => new Result<T> { isSuccess = true, Data = data, Message = message };

        /// <summary>
        /// Creates a failure result with the specified error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <returns>A failed <see cref="Result{T}"/> instance.</returns>
        public static Result<T> Fail(string message)
            => new Result<T> { isSuccess = false, Message = message };
    }
}
