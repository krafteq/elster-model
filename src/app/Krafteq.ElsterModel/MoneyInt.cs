namespace Krafteq.ElsterModel
{
    using System;
    using Krafteq.ElsterModel.ValidationCore;
    using LanguageExt;

    /// <summary>
    /// Represents valid money value rounded to Integer
    /// Value must be maximum 13 digits before decimal point
    /// Can be negative
    /// </summary>
    public class MoneyInt : NewType<MoneyInt, decimal>
    {
        static readonly Validator<NumericError, decimal> Validator = Validators.All(
            NumberValidators.LessThan(10000000000000m)
        );
        
        MoneyInt(decimal value) : base(value)
        {
        }

        public static MoneyInt Create(int intValue) => new MoneyInt(intValue);

        /// <summary>
        /// Usually used for Expenses in the UstVa report
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static Validation<NumericError, MoneyInt> RoundUp(decimal decimalValue) =>
            Validator(decimalValue).Map(x => new MoneyInt(Math.Ceiling(x)));

        /// <summary>
        /// Usually used for Income in the UstVa report
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static Validation<NumericError, MoneyInt> RoundDown(decimal decimalValue) =>
            Validator(decimalValue).Map(x => new MoneyInt(Math.Floor(x)));
        
        public static implicit operator decimal(MoneyInt money) => money.Value;
    }
}