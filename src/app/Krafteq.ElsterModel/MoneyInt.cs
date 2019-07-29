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
        public static Either<Error, MoneyInt> RoundUp(decimal decimalValue) =>
            Validate(decimalValue).Map(x => new MoneyInt(Math.Ceiling(x)));

        /// <summary>
        /// Usually used for Income in the UstVa report
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static Either<Error, MoneyInt> RoundDown(decimal decimalValue) =>
            Validate(decimalValue).Map(x => new MoneyInt(Math.Floor(x)));

        static Either<Error, decimal> Validate(decimal value) =>
            Math.Abs(value) > 9999999999999m 
                ? (Either<Error, decimal>) new Error("value must be less than 10^13") 
                : value; //13 digits
        
        public static implicit operator decimal(MoneyInt money) => money.Value;
    }
}