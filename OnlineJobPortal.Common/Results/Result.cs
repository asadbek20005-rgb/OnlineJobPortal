namespace OnlineJobPortal.Common.Results;

public class Result<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }

    public static Result<T> SuccessResult(T data, string message = "Success")
    {
        return new Result<T> { Success = true, Message = message, Data = data };
    }

    public static Result<T> Failure(string message)
    {
        return new Result<T> { Success = false, Message = message, Data = default };
    }
}