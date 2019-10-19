namespace Krafteq.ElsterModel.Processes.Usta
{
    using Krafteq.ElsterModel.ValidationCore;
    using LanguageExt;

    public class DataSupplierStreet : NewType<DataSupplierStreet, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MinLength(1),
            StringValidators.MaxLength(30)
        );
        
        public static Validation<StringError, DataSupplierStreet> Create(string value) =>
            Validator(value).Map(x => new DataSupplierStreet(x));
        
        DataSupplierStreet(string value) : base(value)
        {
        }
    }
}