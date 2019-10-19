namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class Box : NewType<Box, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MaxLength(10)
        );
        
        Box(string value) : base(value)
        {
        }

        public static Validation<StringError, Box> Create(string value) =>
            Validator(value).Map(x => new Box(x));
    }
}