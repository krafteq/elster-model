namespace Krafteq.ElsterModel
{
    using LanguageExt;

    public class KzFieldValidationError
    {
        public KzFieldValidationError(int fieldNumber, Lst<Error> errors)
        {
            this.FieldNumber = fieldNumber;
            this.Errors = errors;
        }

        public int FieldNumber { get; }
        
        public Lst<Error> Errors { get; }
    }
}