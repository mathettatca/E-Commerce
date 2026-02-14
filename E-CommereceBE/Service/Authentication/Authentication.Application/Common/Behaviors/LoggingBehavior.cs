using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Results;
using System.Diagnostics;

namespace Authentication.Application.Common.Behaviors;

public sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var response = await next();
            stopwatch.Stop();

            if (response is IResult result && !result.IsSuccess)
            {
                _logger.LogWarning(
                    "Handled {RequestName} in {ElapsedMs}ms with failure code {ErrorCode}",
                    requestName,
                    stopwatch.ElapsedMilliseconds,
                    result.Error?.Code);
            }
            else
            {
                _logger.LogInformation(
                    "Handled {RequestName} in {ElapsedMs}ms successfully",
                    requestName,
                    stopwatch.ElapsedMilliseconds);
            }

            return response;
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            _logger.LogError(
                ex,
                "Unhandled exception while handling {RequestName} after {ElapsedMs}ms",
                requestName,
                stopwatch.ElapsedMilliseconds);
            throw;
        }
    }
}
