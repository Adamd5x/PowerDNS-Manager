#nullable enable

namespace hiPower.Dto;

public class ApiResult<TData>(bool success)
{
    public bool Success => success;
    public string? Message { get; set; }
    public string? Code { get; }

    public TData? Data { get; }



    public ApiResult(bool success, string code, string message) : this(success)
    {
        Code = code;
        Message = message;
    }

    public ApiResult(bool success, TData data): this(success)
    {
        Data = data;
    }

    public ApiResult(bool success, string code, string message, TData data) : this(success, code, message)
    {
        Data = data;
    }
}
