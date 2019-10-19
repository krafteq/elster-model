namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class City : NewType<City, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MaxLength(34)
        );
        
        City(string value) : base(value)
        {
        }

        public static Validation<StringError, City> Create(string value) =>
            Validator(value).Map(x => new City(x));
    }
}