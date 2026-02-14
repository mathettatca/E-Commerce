
public sealed class ApiLogRecord
{
    public DateTime TimestampUtc { get; init; } = DateTime.UtcNow;
    public string Method { get; init; } = string.Empty;
    public string Path { get; init; } = string.Empty;
    public string? QueryString { get; init; }
    public int StatusCode { get; init; }
    public long DurationMs { get; init; }
    public string? UserId { get; init; }
    public string? Data { get; init; }
    public string? TraceId { get; init; }
    public string? ClientIp { get; init; }
    public string? UserAgent { get; init; }
    public string? Module {get;set;}
}

public sealed class ErrorLogRecord
{
    public DateTime TimestampUtc { get; init; } = DateTime.UtcNow;
    public string Method { get; init; } = string.Empty;
    public string Path { get; init; } = string.Empty;
    public string? QueryString { get; init; }
    public string? UserId { get; init; }
    public string? TraceId { get; init; }
    public string? ClientIp { get; init; }
    public string? UserAgent { get; init; }
    public int StatusCode { get; init; }
    public string ExceptionType { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public string? StackTrace { get; init; }
    public string? RequestBody { get; init; }
}
