using Authentication.Application.Features.Auth.DTOs;
using MediatR;
using Shared.Results;

namespace Authentication.Application.Features.Auth.Commands.Login;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponseDto>>
{
    public Task<Result<LoginResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (request.Username == "test" && request.Password == "test")
        {
            var response = new LoginResponseDto
            {
                AccessToken = "fake-access-token",
                RefreshToken = "fake-refresh-token"
            };

            return Task.FromResult(Result.Success(response));
        }

        return Task.FromResult(Result.Failure<LoginResponseDto>(
            Error.Create(ErrorCodes.AuthInvalidCredentials, "Invalid username or password.")));
    }
}
