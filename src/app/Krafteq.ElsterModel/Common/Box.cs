namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class Box : NewType<Box, string>
    {
        static readonly StringValidator Validator = StringValidator.Max(10);
        Box(string value) : base(value)
        {
        }

        public static Either<Error, Box> Create(string value) =>
            Validator.Validate(value).Map(x => new Box(x));
    }
}