using Authentication.Application.Features.Auth.DTOs;
using MediatR;
using Shared.Results;

namespace Authentication.Application.Features.Auth.Commands.Login;

public sealed class LoginCommand : IRequest<Result<LoginResponseDto>>
{
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
