namespace Krafteq.ElsterModel.Processes.Usta
{
    using LanguageExt;

    public class DataSupplierZip : NewType<DataSupplierZip, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MinLength(1),
            StringValidators.MaxLength(12)
        );
        
        public static Validation<StringError, DataSupplierZip> Create(string value) =>
            Validator(value).Map(x => new DataSupplierZip(x));
        
        DataSupplierZip(string value) : base(value)
        {
        }
    }
}