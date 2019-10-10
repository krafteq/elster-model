namespace Krafteq.ElsterModel.Processes.Usta
{
    using LanguageExt;

    public class DataSupplierStreet : NewType<DataSupplierStreet, string>
    {
        static readonly StringValidator Validator = StringValidator.MinMax(1, 30);
        
        public static Either<Error, DataSupplierStreet> Create(string value) =>
            Validator.Validate(value).Map(x => new DataSupplierStreet(x));
        
        DataSupplierStreet(string value) : base(value)
        {
        }
    }
}