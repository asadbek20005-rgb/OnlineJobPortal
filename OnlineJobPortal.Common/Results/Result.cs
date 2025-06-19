namespace OnlineJobPortal.Common.Results;

public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public string? Error { get; private set; }
    public T? Value { get; private set; }


    public Result(bool isSuccess, string? error, T? value)
    {
        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }


    public static Result<T> Success(T value) => new Result<T>(true, default, value);    

    public static Result<T> BadRequest(string error) => new Result<T>(false, error, default);
}
