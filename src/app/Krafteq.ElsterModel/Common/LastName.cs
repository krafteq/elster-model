namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class LastName : NewType<LastName, string>
    {
        static readonly StringValidator Validator = StringValidator.Max(60);
        LastName(string value) : base(value)
        {
        }

        public static Either<Error, LastName> Create(string value) =>
            Validator.Validate(value).Map(x => new LastName(x));
    }
}