namespace Krafteq.ElsterModel.ValidationCore
{
    using System;
    using LanguageExt;
    using static LanguageExt.Prelude;
    
    using NumberValidator = Validator<NumericError, decimal>;
    
    static class NumberValidators
    {
        public static NumberValidator LessThan(decimal value) =>
            v => Optional(v)
                .Filter(x => x < value)
                .ToValidation(NumericError.LessThan(value));

        public static NumberValidator NonNegative() =>
            v => Optional(v)
                .Filter(x => x >= 0)
                .ToValidation(NumericError.NonNegative());
    }

    public class NumericError
    {
        public decimal? lessThan;
        public bool nonNegative;

        NumericError(){}
        
        public static NumericError LessThan(decimal value) =>
            new NumericError {lessThan = value};

        public static NumericError NonNegative() =>
            new NumericError {nonNegative = true};

        public T Match<T>(Func<Unit, T> whenNonNegative,
            Func<decimal, T> whenLessThan,
            Func<NumericError, T> whenOther
        )
        {
            if (this.nonNegative)
                return whenNonNegative(unit);

            if (this.lessThan != null)
                return whenLessThan(this.lessThan.Value);

            return whenOther(this);
        }
    }
}