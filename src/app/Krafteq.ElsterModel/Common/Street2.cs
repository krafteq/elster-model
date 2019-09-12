namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class Street2 : NewType<Street2, string>
    {
        static readonly StringValidator Validator = StringValidator.Max(40);
        
        Street2(string value) : base(value)
        {
        }

        public static Either<Error, Street2> Create(string value) =>
            Validator.Validate(value).Map(x => new Street2(x));
    }
}