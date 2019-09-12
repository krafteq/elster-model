namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class Email : NewType<Email, string>
    {
        
        static readonly StringValidator Validator = StringValidator.Max(70);
        Email(string value) : base(value) {}

        public static Either<Error, Email> Create(string value) =>
            Validator.Validate(value).Map(x => new Email(x));
    }
}