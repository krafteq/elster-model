namespace Krafteq.ElsterModel
{
    using System;
    using Krafteq.ElsterModel.Ustva;

    public class TaxCaseReport
    {
        public string ReportType { get; private set; }
        UstvaReport ustva;
        
        TaxCaseReport(){}

        public static TaxCaseReport Ustva(UstvaReport ustva) =>
            new TaxCaseReport {ustva = ustva, ReportType = "ustva"};

        public T Match<T>(
            Func<UstvaReport, T> whenUstva,
            Func<TaxCaseReport, T> fallback
        )
        {
            if (this.ustva != null)
                return whenUstva(this.ustva);

            return fallback(this);
        }

        public override string ToString() => $"Tax Case for [{this.ReportType}]";
    }
}