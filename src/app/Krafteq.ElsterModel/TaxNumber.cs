namespace Krafteq.ElsterModel
{
    using LanguageExt;

    public class TaxNumber : NewType<TaxNumber, string>
    {
        static readonly StringValidator Validator = StringValidator.Exact(13);

        TaxNumber(string value) : base(value)
        {
        }

        public static Either<Error, TaxNumber> Create(string value) =>
            Validator.Validate(value).Map(x => new TaxNumber(x));
    }
}