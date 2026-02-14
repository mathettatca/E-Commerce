using MediatR;
using Shared.Results;

namespace Authentication.Application.Features.Auth.Queries.Ping;

public sealed class PingQueryHandler : IRequestHandler<PingQuery, Result<string>>
{
    public Task<Result<string>> Handle(PingQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success("pong"));
    }
}
