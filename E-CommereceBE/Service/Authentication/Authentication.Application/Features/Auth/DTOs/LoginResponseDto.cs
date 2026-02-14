namespace Authentication.Application.Features.Auth.DTOs;

public sealed class LoginResponseDto
{
    public string AccessToken { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
}
