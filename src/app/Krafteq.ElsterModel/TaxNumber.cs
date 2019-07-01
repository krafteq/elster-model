namespace Krafteq.ElsterModel
{
    using LanguageExt;

    public class TaxNumber : NewType<TaxNumber, string>
    {
        TaxNumber(string value) : base(value)
        {
        }

        public static Option<TaxNumber> Create(string value)
        {
            // it could be better validation with a checksum 
            if (value.Length != 13)
                return Prelude.None;

            return new TaxNumber(value);
        }
    }
}