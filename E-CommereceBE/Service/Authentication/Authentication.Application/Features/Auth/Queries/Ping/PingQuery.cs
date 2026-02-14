using MediatR;
using Shared.Results;

namespace Authentication.Application.Features.Auth.Queries.Ping;

public sealed record PingQuery : IRequest<Result<string>>;
