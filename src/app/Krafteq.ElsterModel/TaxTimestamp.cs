namespace Krafteq.ElsterModel
{
    using System;

    public class TaxTimestamp
    {
        public TaxYear Year { get; }
        public TaxTimePeriod TimePeriod { get; }

        public TaxTimestamp(TaxYear year, TaxTimePeriod timePeriod)
        {
            this.Year = year ?? throw new ArgumentNullException(nameof(year));
            this.TimePeriod = timePeriod ?? throw new ArgumentNullException(nameof(timePeriod));
        }
    }
}