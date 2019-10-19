namespace Krafteq.ElsterModel
{
    using System;
    using Krafteq.ElsterModel.ValidationCore;
    using LanguageExt;
    
    using static LanguageExt.Prelude;

    public class KzFieldError
    {
        public static readonly KzFieldError UnknownField = new KzFieldError { unknown = true };
        public static readonly KzFieldError Required = new KzFieldError { required = true };
        public static readonly KzFieldError DecimalPresentationError = new KzFieldError { decimalPresentationError = true};
        public static readonly KzFieldError BooleanPresentationError = new KzFieldError { booleanPresentationError = true};
        public static readonly KzFieldError Negative = new KzFieldError {negative = true};

        bool unknown;
        bool required;
        bool decimalPresentationError;
        bool booleanPresentationError;
        bool negative;

        decimal? lessThanValue;
        int? lessThanFieldNumber;
        (decimal value, decimal eps)? closeToValue;
        
        KzFieldError(){}

        public static KzFieldError MustBeLessThan(decimal value) => new KzFieldError {lessThanValue = value};

        public static KzFieldError MustBeLessThanAnotherField(int fieldNumber) =>
            new KzFieldError {lessThanFieldNumber = fieldNumber};
        
        public static KzFieldError FromDecimalValidationError(NumericError numericError) =>
            numericError.Match(
                whenNonNegative: _ => Negative,
                whenLessThan: MustBeLessThan,
                _ => throw new NotImplementedException()
            );

        public static KzFieldError MustBeCloseToValue(decimal value, decimal eps) => 
            new KzFieldError{ closeToValue = (value, eps)};
        
        public T Match<T>(
            Func<Unit, T> whenUnknownField,
            Func<Unit, T> whenRequired,
            Func<Unit, T> whenDecimalPresentationError,
            Func<Unit, T> whenBooleanPresentationError,
            Func<Unit, T> whenNegative,
            Func<decimal, T> whenMustBeLessThan,
            Func<int, T> whenMustBeLessThanAnotherField,
            Func<(decimal value, decimal eps), T> whenMustBeCloseToValue,
            Func<KzFieldError, T> fallback
        )
        {
            if (this.unknown) return whenUnknownField(unit);
            if (this.required) return whenRequired(unit);
            if (this.decimalPresentationError) return whenDecimalPresentationError(unit);
            if (this.booleanPresentationError) return whenBooleanPresentationError(unit);
            if (this.negative) return whenNegative(unit);
            if (this.lessThanValue != null) return whenMustBeLessThan(this.lessThanValue.Value);
            if (this.lessThanFieldNumber != null) return whenMustBeLessThanAnotherField(this.lessThanFieldNumber.Value);
            if (this.closeToValue != null) return whenMustBeCloseToValue(this.closeToValue.Value);

            return fallback(this);
        }
    }
}