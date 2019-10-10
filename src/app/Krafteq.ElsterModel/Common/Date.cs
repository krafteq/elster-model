namespace Krafteq.ElsterModel.Common
{
    using System;
    using LanguageExt;

    public class Date : NewType<Date, DateTime>
    {
        public Date(DateTime value) : base(value.Date)
        {
        }

        public static Date Create(DateTime value) => new Date(value);

        public override string ToString() => this.Value.ToShortDateString();
    }
}