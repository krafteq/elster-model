namespace Krafteq.ElsterModel.Processes.Usta.Ustva
{
    using System;

    public class UstvaReport
    {
        public TaxTimestamp Timestamp { get; }
        public TaxNumber TaxNumber { get; }
        public UstvaKzFields Kz { get; }
        public ReportSource Source { get; }
        
        public UstvaReport(
            TaxTimestamp timestamp,
            TaxNumber taxNumber,
            UstvaKzFields kz,
            ReportSource source)
        {
            this.Timestamp = timestamp ?? throw new ArgumentNullException(nameof(timestamp));
            this.TaxNumber = taxNumber ?? throw new ArgumentNullException(nameof(taxNumber));
            this.Kz = kz ?? throw new ArgumentNullException(nameof(kz));
            this.Source = source ?? throw new ArgumentNullException(nameof(source));
        }
    }
}