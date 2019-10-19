namespace Krafteq.ElsterModel
{
    using LanguageExt;

    public class KzFieldValidationError
    {
        public KzFieldValidationError(int fieldNumber, Lst<KzFieldError> errors)
        {
            this.FieldNumber = fieldNumber;
            this.Errors = errors;
        }

        public int FieldNumber { get; }
        
        public Lst<KzFieldError> Errors { get; }
    }
}