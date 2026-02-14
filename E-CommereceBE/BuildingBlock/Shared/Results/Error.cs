namespace Shared.Results;

public sealed class Error
{
    private Error(string code, string message, Dictionary<string, string[]>? details)
    {
        Code = code;
        Message = message;
        Details = details;
    }

    public string Code { get; }

    public string Message { get; }

    public Dictionary<string, string[]>? Details { get; }

    public static Error Create(string code, string message, Dictionary<string, string[]>? details = null)
    {
        return new Error(code, message, details);
    }

    public static Error Validation(string message, Dictionary<string, string[]> details)
    {
        return new Error(ErrorCodes.ValidationFailed, message, details);
    }
}
