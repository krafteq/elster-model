namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class AdditionalHouseNumber : NewType<AdditionalHouseNumber, string>
    {
        static readonly StringValidator Validator = StringValidator.Max(15);
        
        AdditionalHouseNumber(string value) : base(value)
        {
        }

        public static Either<Error, AdditionalHouseNumber> Create(string value) =>
            Validator.Validate(value).Map(x => new AdditionalHouseNumber(x));
    }
}