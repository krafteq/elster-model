namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class AdditionalHouseNumber : NewType<AdditionalHouseNumber, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MaxLength(15)
        );
        
        AdditionalHouseNumber(string value) : base(value)
        {
        }

        public static Validation<StringError, AdditionalHouseNumber> Create(string value) =>
            Validator(value).Map(x => new AdditionalHouseNumber(x));
    }
}