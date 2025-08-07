namespace CreditApprovalAPI.Services.Utilities
{
    public class Result<T>
    {
        public bool isSuccess { get; set; }

        public string? Message { get; set; }

        public T? Data { get; set; }

        public static Result<T> Ok(T data, string? message = null)
            => new Result<T> { isSuccess = true, Data = data, Message = message };

        public static Result<T> Fail(string message)
            => new Result<T> { isSuccess = false, Message = message };
    }
}
