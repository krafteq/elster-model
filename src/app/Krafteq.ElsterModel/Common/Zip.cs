namespace Krafteq.ElsterModel.Common
{
    using Krafteq.ElsterModel.ValidationCore;
    using LanguageExt;

    public class Zip : NewType<Zip, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.ExactLength(5),
            StringValidators.DigitsOnly()
        );

        Zip(string value) : base(value)
        {
        }

        public static Validation<StringError, Zip> Create(string value) =>
            Validator(value).Map(x => new Zip(x));
    }
}