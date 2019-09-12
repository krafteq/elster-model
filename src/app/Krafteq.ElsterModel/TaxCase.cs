namespace Krafteq.ElsterModel
{
    using System;
    using Krafteq.ElsterModel.Common;
    using LanguageExt;

    public class TaxCase
    {
        public Option<AccountantInfo> Accountant { get; }
        public CompanyInfo Company { get; }
        public TaxCaseReport Report { get; }

        public TaxCase(TaxCaseReport report, CompanyInfo company, Option<AccountantInfo> accountant)
        {
            this.Accountant = accountant;
            this.Company = company ?? throw new ArgumentNullException(nameof(company));
            this.Report = report ?? throw new ArgumentNullException(nameof(report));
        }
    }
}