namespace Authentication.Application.Common.Validation;

public sealed class ValidationResult
{
    public ValidationResult(IEnumerable<ValidationFailure> errors)
    {
        Errors = errors.ToArray();
    }

    public IReadOnlyCollection<ValidationFailure> Errors { get; }

    public bool IsValid => Errors.Count == 0;

    public static ValidationResult Success() => new([]);
}
