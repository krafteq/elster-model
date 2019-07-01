namespace Krafteq.ElsterModel
{
    using System;
    using LanguageExt;

    /// <summary>
    /// Represents valid money value rounded to 0.01
    /// Value must be maximum 11 digits before decimal point
    /// Cannot be negative
    /// </summary>
    public class UnsignedMoney : NewType<UnsignedMoney, decimal>
    {
        UnsignedMoney(decimal value) 
            : base(value)
        {
        }

        public static UnsignedMoney Create(uint uintValue) => new UnsignedMoney(uintValue);

        /// <summary>
        /// Usually used for Expenses in the UstVa report
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static UnsignedMoney RoundUp(decimal decimalValue) =>
            new UnsignedMoney(Money.RoundUp(Validate(decimalValue)).Value);

        /// <summary>
        /// Usually used for Income in the UstVa report
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static UnsignedMoney RoundDown(decimal decimalValue) =>
            new UnsignedMoney(Money.RoundDown(Validate(decimalValue)).Value);

        static decimal Validate(decimal value) =>
            value < 0 ? throw new InvalidOperationException("value must be not-negative") : value;
        
        public static implicit operator decimal(UnsignedMoney money) => money.Value;
    }
}