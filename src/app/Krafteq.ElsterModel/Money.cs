namespace Krafteq.ElsterModel
{
    using System;
    using System.Runtime.CompilerServices;
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
        public static Either<Error, Money> RoundUp(decimal decimalValue) =>
            Validate(decimalValue).Map(x => new Money(Math.Ceiling(x * 100) / 100));
        
        /// <summary>
        /// Usually used for Income in the UstVa report
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static Either<Error, Money> RoundDown(decimal decimalValue) =>
            Validate(decimalValue).Map(x => new Money(Math.Floor(x * 100) / 100));
        
        static Either<Error, decimal> Validate(decimal value) =>
            Math.Abs(value) > 99999999999m 
                ? (Either<Error, decimal>) new Error("value must be less than 10^11") 
                : value; //11 digits, 2 decimal

        public static implicit operator decimal(Money money) => money.Value;
    }
}