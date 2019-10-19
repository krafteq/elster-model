namespace Krafteq.ElsterModel.Processes.Usta
{
    using Krafteq.ElsterModel.ValidationCore;
    using LanguageExt;

    public class DataSupplierCity : NewType<DataSupplierCity, string>
    {
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.MinLength(1),
            StringValidators.MaxLength(30)
        );
        
        public static Validation<StringError, DataSupplierCity> Create(string value) =>
            Validator(value).Map(x => new DataSupplierCity(x));
        
        DataSupplierCity(string value) : base(value)
        {
        }
    }
}