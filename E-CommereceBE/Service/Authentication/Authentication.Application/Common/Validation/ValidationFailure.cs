namespace Authentication.Application.Common.Validation;

public sealed record ValidationFailure(string PropertyName, string ErrorMessage);
