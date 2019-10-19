namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class FirstName : NewType<FirstName, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MaxLength(30)
        );
        
        FirstName(string value) : base(value)
        {
        }

        public static Validation<StringError, FirstName> Create(string value) =>
            Validator(value).Map(x => new FirstName(x));
    }
}