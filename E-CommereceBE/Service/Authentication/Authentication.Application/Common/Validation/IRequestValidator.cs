namespace Authentication.Application.Common.Validation;

public interface IRequestValidator<in TRequest>
{
    Task<ValidationResult> ValidateAsync(TRequest request, CancellationToken ct);
}
