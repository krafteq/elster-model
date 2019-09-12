namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class ZipForeign : NewType<ZipForeign, string>
    {
        static readonly StringValidator Validator = StringValidator.Max(13);
        ZipForeign(string value) : base(value)
        {
        }

        public static Either<Error, ZipForeign> Create(string value) =>
            Validator.Validate(value).Map(x => new ZipForeign(x));
    }
}