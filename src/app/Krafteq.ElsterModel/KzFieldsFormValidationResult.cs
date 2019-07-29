namespace Krafteq.ElsterModel
{
    using System;
    using System.Linq;

    public class KzFieldsFormValidationResult
    {
        public KzFieldSet ValidFieldSet { get; }
        public KzFieldFormValidationError ValidationError { get; }
        
        public bool IsValid => !this.ValidationError.Errors.Any();

        public KzFieldsFormValidationResult(KzFieldSet validFieldSet, KzFieldFormValidationError validationError)
        {
            this.ValidFieldSet = validFieldSet ?? throw new ArgumentNullException(nameof(validFieldSet));
            this.ValidationError = validationError ?? throw new ArgumentNullException(nameof(validationError));
        }
    }
}