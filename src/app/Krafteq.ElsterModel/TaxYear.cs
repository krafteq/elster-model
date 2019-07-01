namespace Krafteq.ElsterModel
{
    using LanguageExt;

    public class TaxYear : NewType<TaxYear, int>
    {
        public TaxYear(int value) : base(value)
        {
        }

        public static TaxYear Create(int value) => new TaxYear(value);
    }
}