namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class City : NewType<City, string>
    {
        static readonly StringValidator Validator = StringValidator.Max(34);
        City(string value) : base(value)
        {
        }

        public static Either<Error, City> Create(string value) =>
            Validator.Validate(value).Map(x => new City(x));
    }
}