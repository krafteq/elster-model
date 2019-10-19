namespace Krafteq.ElsterModel.Common
{
    using Krafteq.ElsterModel.ValidationCore;
    using LanguageExt;

    public class Email : NewType<Email, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MaxLength(70)
        );
        
        Email(string value) : base(value) {}

        public static Validation<StringError, Email> Create(string value) =>
            Validator(value).Map(x => new Email(x));
    }
}