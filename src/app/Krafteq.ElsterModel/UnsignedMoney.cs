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
        public static Either<Error, UnsignedMoney> RoundUp(decimal decimalValue) =>
            Validate(decimalValue).Bind(Money.RoundUp).Map(x => new UnsignedMoney(x.Value));

        /// <summary>
        /// Usually used for Income in the UstVa report
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static Either<Error, UnsignedMoney> RoundDown(decimal decimalValue) =>
            Validate(decimalValue).Bind(Money.RoundDown).Map(x => new UnsignedMoney(x.Value));

        static Either<Error, decimal> Validate(decimal value) =>
            value < 0 ? (Either<Error, decimal>) new Error("value must be not-negative") : value;
        
        public static implicit operator decimal(UnsignedMoney money) => money.Value;
    }
}