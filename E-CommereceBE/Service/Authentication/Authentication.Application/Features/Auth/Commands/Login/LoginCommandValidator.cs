using Authentication.Application.Common.Validation;

namespace Authentication.Application.Features.Auth.Commands.Login;

public sealed class LoginCommandValidator : IRequestValidator<LoginCommand>
{
    public Task<ValidationResult> ValidateAsync(LoginCommand request, CancellationToken ct)
    {
        var failures = new List<ValidationFailure>();

        if (string.IsNullOrWhiteSpace(request.Username))
        {
            failures.Add(new ValidationFailure(nameof(request.Username), "Username is required."));
        }

        if (string.IsNullOrWhiteSpace(request.Password))
        {
            failures.Add(new ValidationFailure(nameof(request.Password), "Password is required."));
        }

        return Task.FromResult(new ValidationResult(failures));
    }
}
