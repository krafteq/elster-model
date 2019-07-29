namespace Krafteq.ElsterModel
{
    using LanguageExt;

    public class KzFieldFormValidationError
    {
        public KzFieldFormValidationError(Lst<KzFieldValidationError> errors)
        {
            this.Errors = errors;
        }

        public Lst<KzFieldValidationError> Errors { get; }
    }
}