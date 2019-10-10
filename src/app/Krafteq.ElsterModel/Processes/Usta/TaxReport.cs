namespace Krafteq.ElsterModel.Processes.Usta
{
    using System;
    using Krafteq.ElsterModel.Processes.Usta.Ustva;

    public class TaxReport
    {
        public string ReportType { get; private set; }
        UstvaReport ustva;
        
        TaxReport(){}

        public static TaxReport Ustva(UstvaReport ustva) =>
            new TaxReport {ustva = ustva, ReportType = "ustva"};

        public T Match<T>(
            Func<UstvaReport, T> whenUstva,
            Func<TaxReport, T> fallback
        )
        {
            if (this.ustva != null)
                return whenUstva(this.ustva);

            return fallback(this);
        }

        public override string ToString() => $"Tax Case for [{this.ReportType}]";
    }
}