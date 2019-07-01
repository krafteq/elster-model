namespace Krafteq.ElsterModel
{
    using System;
    using LanguageExt;

    /// <summary>
    /// Represents valid money value rounded to 0.01
    /// Value must be maximum 11 digits before decimal point
    /// Can be negative
    /// </summary>
    public class Money : NewType<Money, decimal>
    {
        Money(decimal value) : base(value)
        {
        }

        /// <summary>
        /// Usually used for Expenses in the UstVa report
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static Money RoundUp(decimal decimalValue) =>
            new Money(Math.Ceiling(Validate(decimalValue)*100)/100);
        
        /// <summary>
        /// Usually used for Income in the UstVa report
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static Money RoundDown(decimal decimalValue) =>
            new Money(Math.Floor(Validate(decimalValue)*100)/100);
        
        static decimal Validate(decimal value) =>
            Math.Abs(value) > 99999999999m 
                ? throw new InvalidOperationException("value must be less than 10^11") 
                : value; //11 digits, 2 decimal

        public static implicit operator decimal(Money money) => money.Value;
    }
}