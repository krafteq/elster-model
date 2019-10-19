namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class Country : NewType<Country, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MaxLength(20)
        );
        
        Country(string value) : base(value)
        {
        }

        public static Validation<StringError, Country> Create(string value) =>
            Validator(value).Map(x => new Country(x));
    }
}