namespace Krafteq.ElsterModel
{
    using System;
    using Krafteq.ElsterModel.ValidationCore;
    using LanguageExt;

    /// <summary>
    /// Represents valid money value rounded to 0.01
    /// Value must be maximum 11 digits before decimal point
    /// Cannot be negative
    /// </summary>
    public class UnsignedMoney : NewType<UnsignedMoney, decimal>
    {
        static readonly Validator<NumericError, decimal> Validator = Validators.All(
            NumberValidators.LessThan(100000000000m),
            NumberValidators.NonNegative()
        );
        
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
        public static Validation<NumericError, UnsignedMoney> RoundUp(decimal decimalValue) =>
            Validator(decimalValue).Bind(Money.RoundUp).Map(x => new UnsignedMoney(x.Value));

        /// <summary>
        /// Usually used for Income in the UstVa report
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static Validation<NumericError, UnsignedMoney> RoundDown(decimal decimalValue) =>
            Validator(decimalValue).Bind(Money.RoundDown).Map(x => new UnsignedMoney(x.Value));
        
        
        public static implicit operator decimal(UnsignedMoney money) => money.Value;
    }
}