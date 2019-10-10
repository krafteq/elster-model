namespace Krafteq.ElsterModel.Processes.Usta
{
    using System;
    using Krafteq.ElsterModel.Common;

    public class UstaPayload
    {
        public TaxCase TaxCase { get; }
        public DataSupplier DataSupplier { get; }
        public Date CreationDate { get; }

        public UstaPayload(TaxCase taxCase, DataSupplier dataSupplier, Date creationDate)
        {
            this.TaxCase = taxCase ?? throw new ArgumentNullException(nameof(taxCase));
            this.DataSupplier = dataSupplier ?? throw new ArgumentNullException(nameof(dataSupplier));
            this.CreationDate = creationDate ?? throw new ArgumentNullException(nameof(creationDate));
        }
    }
}