namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class FirstName : NewType<FirstName, string>
    {
        static readonly StringValidator Validator = StringValidator.Max(30);
        FirstName(string value) : base(value)
        {
        }

        public static Either<Error, FirstName> Create(string value) =>
            Validator.Validate(value).Map(x => new FirstName(x));
    }
}