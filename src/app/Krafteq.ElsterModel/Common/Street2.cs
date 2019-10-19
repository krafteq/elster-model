namespace Krafteq.ElsterModel.Common
{
    using Krafteq.ElsterModel.ValidationCore;
    using LanguageExt;

    public class Street2 : NewType<Street2, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MaxLength(40)
        );
        
        Street2(string value) : base(value)
        {
        }

        public static Validation<StringError, Street2> Create(string value) =>
            Validator(value).Map(x => new Street2(x));
    }
}