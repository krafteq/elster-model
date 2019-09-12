namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class Street : NewType<Street, string>
    {
        static readonly StringValidator Validator = StringValidator.Max(33);
        
        Street(string value) : base(value)
        {
        }

        public static Either<Error, Street> Create(string value) =>
            Validator.Validate(value).Map(x => new Street(x));
    }
}