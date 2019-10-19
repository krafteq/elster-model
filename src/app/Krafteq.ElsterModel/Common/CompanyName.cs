namespace Krafteq.ElsterModel.Common
{
    using Krafteq.ElsterModel.ValidationCore;
    using LanguageExt;

    public class CompanyName : NewType<CompanyName, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MaxLength(50)
        );
        
        CompanyName(string value) : base(value)
        {
        }

        public static Validation<StringError, CompanyName> Create(string value) =>
            Validator(value).Map(x => new CompanyName(x));
    }
}