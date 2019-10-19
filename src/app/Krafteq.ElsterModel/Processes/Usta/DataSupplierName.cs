namespace Krafteq.ElsterModel.Processes.Usta
{
    using LanguageExt;

    public class DataSupplierName : NewType<DataSupplierName, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MinLength(1),
            StringValidators.MaxLength(45)
        );
        
        public static Validation<StringError, DataSupplierName> Create(string value) =>
            Validator(value).Map(x => new DataSupplierName(x));
        
        DataSupplierName(string value) : base(value)
        {
        }
    }
}