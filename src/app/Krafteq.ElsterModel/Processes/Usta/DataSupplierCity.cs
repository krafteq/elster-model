namespace Krafteq.ElsterModel.Processes.Usta
{
    using LanguageExt;

    public class DataSupplierCity : NewType<DataSupplierCity, string>
    {
        static readonly StringValidator Validator = StringValidator.MinMax(1, 30);
        
        public static Either<Error, DataSupplierCity> Create(string value) =>
            Validator.Validate(value).Map(x => new DataSupplierCity(x));
        
        DataSupplierCity(string value) : base(value)
        {
        }
    }
}