namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class Zip : NewType<Zip, string>
    {
        static readonly StringValidator Validator = StringValidator.Exact(5);
        
        Zip(string value) : base(value)
        {
        }

        public static Either<Error, Zip> Create(string value) =>
            Validator.Validate(value).Map(x => new Zip(x));
    }
}