namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class Country : NewType<Country, string>
    {
        static readonly StringValidator Validator = StringValidator.Max(20);
        Country(string value) : base(value)
        {
        }

        public static Either<Error, Country> Create(string value) =>
            Validator.Validate(value).Map(x => new Country(x));
    }
}