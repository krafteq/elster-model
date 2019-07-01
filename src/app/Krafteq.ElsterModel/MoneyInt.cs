namespace Krafteq.ElsterModel
{
    using System;
    using LanguageExt;

    /// <summary>
    /// Represents valid money value rounded to Integer
    /// Value must be maximum 13 digits before decimal point
    /// Can be negative
    /// </summary>
    public class MoneyInt : NewType<MoneyInt, decimal>
    {
        MoneyInt(decimal value) : base(value)
        {
        }

        public static MoneyInt Create(int intValue) => new MoneyInt(intValue);

        /// <summary>
        /// Usually used for Expenses in the UstVa report
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static MoneyInt RoundUp(decimal decimalValue) =>
            new MoneyInt(Math.Ceiling(Validate(decimalValue)));

        /// <summary>
        /// Usually used for Income in the UstVa report
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static MoneyInt RoundDown(decimal decimalValue) =>
            new MoneyInt(Math.Floor(Validate(decimalValue)));

        static decimal Validate(decimal value) =>
            Math.Abs(value) > 9999999999999m 
                ? throw new InvalidOperationException("value must be less than 10^13") 
                : value; //13 digits
        
        public static implicit operator decimal(MoneyInt money) => money.Value;
    }
}