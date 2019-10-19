namespace Krafteq.ElsterModel.Common
{
    using Krafteq.ElsterModel.ValidationCore;
    using LanguageExt;

    public class LastName : NewType<LastName, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MaxLength(60)
        );
        
        LastName(string value) : base(value)
        {
        }

        public static Validation<StringError, LastName> Create(string value) =>
            Validator(value).Map(x => new LastName(x));
    }
}