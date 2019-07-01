namespace Krafteq.ElsterModel
{
    using System;

    public class TaxTimePeriod
    {
        Month month;
        Quarter quarter;

        TaxTimePeriod()
        {
        }

        public static TaxTimePeriod Month(Month month)
        {
            if (month == null) throw new ArgumentNullException(nameof(month));
            return new TaxTimePeriod
            {
                month = month
            };
        }

        public static TaxTimePeriod Quarter(Quarter quarter)
        {
            if (quarter == null) throw new ArgumentNullException(nameof(quarter));
            return new TaxTimePeriod
            {
                quarter = quarter
            };
        }

        public T Match<T>(Func<Month, T> whenMonth, Func<Quarter, T> whenQuarter)
        {
            if (this.month != null)
                return whenMonth(this.month);

            return whenQuarter(this.quarter);
        }
    }
}