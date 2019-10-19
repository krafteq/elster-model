namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class ZipForeign : NewType<ZipForeign, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MaxLength(13)
        );
        
        ZipForeign(string value) : base(value)
        {
        }

        public static Validation<StringError, ZipForeign> Create(string value) =>
            Validator(value).Map(x => new ZipForeign(x));
    }
}