namespace Krafteq.ElsterModel.Processes.Usta
{
    using LanguageExt;

    public class DataSupplierName : NewType<DataSupplierName, string>
    {
        static readonly StringValidator Validator = StringValidator.MinMax(1, 45);
        
        public static Either<Error, DataSupplierName> Create(string value) =>
            Validator.Validate(value).Map(x => new DataSupplierName(x));
        
        DataSupplierName(string value) : base(value)
        {
        }
    }
}