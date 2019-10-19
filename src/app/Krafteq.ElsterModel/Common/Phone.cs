namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class Phone : NewType<Phone, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MaxLength(20)
        );
        
        Phone(string value) : base(value)
        {
        }

        public static Validation<StringError, Phone> Create(string value) =>
            Validator(value).Map(x => new Phone(x));
    }
}