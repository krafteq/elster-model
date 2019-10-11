namespace Krafteq.ElsterModel.Processes.Usta
{
    using System;
    using Krafteq.ElsterModel.Common;
    using LanguageExt;

    /// <summary>
    /// Discriminated union with all supported USTA tax cases. By now only Ustva.
    ///
    /// ustva_df and ustva_sovz are coming soon
    /// </summary>
    public class TaxCase
    {
        public Option<CompanyInfo> Accountant { get; }
        public CompanyInfo Company { get; }
        public TaxReport Report { get; }

        public TaxCase(TaxReport report, CompanyInfo company, Option<CompanyInfo> accountant)
        {
            this.Accountant = accountant;
            this.Company = company ?? throw new ArgumentNullException(nameof(company));
            this.Report = report ?? throw new ArgumentNullException(nameof(report));
        }
    }
}