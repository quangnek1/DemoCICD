namespace DemoCICD.Contract.Abstractions.Shared;
public class ValidationResult<TValue> : Result<TValue>, IValidationResult
{
    protected internal ValidationResult(Error[] error) : base(default, false, IValidationResult.ValidationError)
    {
        Errors = error;
    }

    public Error[] Errors { get; }

    public static ValidationResult<TValue> WithError(Error[] errors) => new (errors);
}
