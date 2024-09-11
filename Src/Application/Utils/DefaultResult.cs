namespace Application.Utils;


public enum ResultMessages
{
    Ok,
    Created,
    Updated,
    Deleted
}

public class DefaultResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public object? Errors { get; set; }

    public static DefaultResult Success(ResultMessages message)
    {
        return new DefaultResult
        {
            IsSuccess = true,
            Message = message.ToString()
        };
    }

    public static DefaultResult Fail(string message, List<string> errors = null)
    {
        return new DefaultResult
        {
            IsSuccess = false,
            Message = message,
            Errors = errors
        };
    }
}

public class DefaultResult<TData> : DefaultResult
{
    public TData Data { get; set; }

    public static DefaultResult<TData> Success (ResultMessages message, TData data)
    {
        return new DefaultResult<TData>
        {
            IsSuccess = true,
            Message = message.ToString (),
            Data = data
        };
    }

    public static DefaultResult<TData> Fail (string message, TData errors)
    {
        return new DefaultResult<TData>
        {
            IsSuccess = false,
            Message = message,
            Errors = errors
        };
    }
}
