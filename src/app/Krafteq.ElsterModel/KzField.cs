namespace Krafteq.ElsterModel
{
    using System;

    public class KzField 
    {
        public int Number { get; }

        public string FormattedValue { get; }
        
        public KzField(int number, string formattedValue)
        {
            this.Number = number;
            this.FormattedValue = formattedValue ?? throw new ArgumentNullException(nameof(formattedValue));
        }
    }
}