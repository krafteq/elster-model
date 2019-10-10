namespace Krafteq.ElsterModel.Processes.Usta
{
    using LanguageExt;

    public class DataSupplierZip : NewType<DataSupplierZip, string>
    {
        static readonly StringValidator Validator = StringValidator.MinMax(1, 12);
        
        public static Either<Error, DataSupplierZip> Create(string value) =>
            Validator.Validate(value).Map(x => new DataSupplierZip(x));
        
        DataSupplierZip(string value) : base(value)
        {
        }
    }
}