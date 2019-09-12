namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class Phone : NewType<Phone, string>
    {
        
        static readonly StringValidator Validator = StringValidator.Max(20);
        Phone(string value) : base(value)
        {
        }

        public static Either<Error, Phone> Create(string value) =>
            Validator.Validate(value).Map(x => new Phone(x));
    }
}