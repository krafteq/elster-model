namespace Krafteq.ElsterModel
{
    using System;
    using System.Runtime.CompilerServices;
    using Krafteq.ElsterModel.ValidationCore;
    using LanguageExt;

    /// <summary>
    /// Represents valid money value rounded to 0.01
    /// Value must be maximum 11 digits before decimal point
    /// Can be negative
    /// </summary>
    public class Money : NewType<Money, decimal>
    {
        static readonly Validator<NumericError, decimal> Validator = Validators.All(
            NumberValidators.LessThan(100000000000m)
        );
        
        Money(decimal value) : base(value)
        {
        }

        /// <summary>
        /// Usually used for Expenses in the UstVa report
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static Validation<NumericError, Money> RoundUp(decimal decimalValue) =>
            Validator(decimalValue).Map(x => new Money(Math.Ceiling(x * 100) / 100));
        
        /// <summary>
        /// Usually used for Income in the UstVa report
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static Validation<NumericError, Money> RoundDown(decimal decimalValue) =>
            Validator(decimalValue).Map(x => new Money(Math.Floor(x * 100) / 100));

        public static implicit operator decimal(Money money) => money.Value;
    }
}