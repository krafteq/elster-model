namespace Krafteq.ElsterModel.Processes.Usta.Ustva
{
    using System;

    public class UstvaReport
    {
        public TaxTimestamp Timestamp { get; }
        public TaxNumber TaxNumber { get; }
        public UstvaKzFields Kz { get; }
        public Kz09 Kz09 { get; }
        
        public UstvaReport(
            TaxTimestamp timestamp,
            TaxNumber taxNumber,
            UstvaKzFields kz,
            Kz09 source)
        {
            this.Timestamp = timestamp ?? throw new ArgumentNullException(nameof(timestamp));
            this.TaxNumber = taxNumber ?? throw new ArgumentNullException(nameof(taxNumber));
            this.Kz = kz ?? throw new ArgumentNullException(nameof(kz));
            this.Kz09 = source ?? throw new ArgumentNullException(nameof(source));
        }
    }
}