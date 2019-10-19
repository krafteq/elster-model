namespace Krafteq.ElsterModel.Common
{
    using Krafteq.ElsterModel.ValidationCore;
    using LanguageExt;

    public class Street : NewType<Street, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MaxLength(33)
        );
        
        Street(string value) : base(value)
        {
        }

        public static Validation<StringError, Street> Create(string value) =>
            Validator(value).Map(x => new Street(x));
    }
}