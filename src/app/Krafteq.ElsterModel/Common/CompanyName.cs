namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class CompanyName : NewType<CompanyName, string>
    {
        static readonly StringValidator Validator = StringValidator.Max(50);
        CompanyName(string value) : base(value)
        {
        }

        public static Either<Error, CompanyName> Create(string value) =>
            Validator.Validate(value).Map(x => new CompanyName(x));
    }
}