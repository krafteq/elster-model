namespace Krafteq.ElsterModel
{
    using System;
    using Krafteq.ElsterModel.ValidationCore;
    using LanguageExt;

    using static LanguageExt.Prelude;

    public class KzFieldType : NewType<KzFieldType, string>
    {
        readonly Func<object, Validation<KzFieldError, KzFieldValue>> valueFactory;

        public static readonly KzFieldType Boolean = new KzFieldType(
            "boolean", BooleanValue);

        public static readonly KzFieldType MoneyIntUp =
            new KzFieldType("money-int.round-up", DecimalValue(KzFieldValue.MoneyInt, MoneyInt.RoundUp));

        public static readonly KzFieldType MoneyIntDown = new KzFieldType(
            "money-int.round-down",
            DecimalValue(KzFieldValue.MoneyInt, MoneyInt.RoundDown));

        public static readonly KzFieldType MoneyUp =
            new KzFieldType("money.round-up", DecimalValue(KzFieldValue.Money, Money.RoundUp));

        public static readonly KzFieldType MoneyDown =
            new KzFieldType("money.round-down", DecimalValue(KzFieldValue.Money, Money.RoundDown));

        public static readonly KzFieldType UnsignedMoneyDown = new KzFieldType("money-unsigned.round-down",
            DecimalValue(KzFieldValue.UnsignedMoney, UnsignedMoney.RoundDown));

        public static readonly KzFieldType UnsignedMoneyUp = new KzFieldType("money-unsigned.round-up",
            DecimalValue(KzFieldValue.UnsignedMoney, UnsignedMoney.RoundUp));

        KzFieldType(string value, Func<object, Validation<KzFieldError, KzFieldValue>> valueFactory) : base(value)
        {
            this.valueFactory = valueFactory;
        }

        public Validation<KzFieldError, KzFieldValue> CreateFieldValue(object value) => this.valueFactory(value);

        static Func<object, Validation<KzFieldError, KzFieldValue>> DecimalValue<T>(
            Func<T, KzFieldValue> fieldValueFactory,
            Func<decimal, Validation<NumericError, T>> intermediateFactory) =>
            DecimalValue(x => intermediateFactory(x).Map(fieldValueFactory));

        static Func<object, Validation<KzFieldError, KzFieldValue>> DecimalValue(
            Func<decimal, Validation<NumericError, KzFieldValue>> fieldValueFactory) =>
            value => CreateDecimal(value)
                .Bind(d => fieldValueFactory(d)
                    .MapFail(KzFieldError.FromDecimalValidationError)
                );

        static Validation<KzFieldError, KzFieldValue> BooleanValue(object value) =>
            CreateBoolean(value).Map(KzFieldValue.Boolean);

        static Validation<KzFieldError, bool> CreateBoolean(object value) =>
            TryCreateBool(value).ToValidation(KzFieldError.BooleanPresentationError);

        static Validation<KzFieldError, decimal> CreateDecimal(object value) =>
            TryCreateDecimal(value).ToValidation(KzFieldError.DecimalPresentationError);

        static Option<bool> TryCreateBool(object value)
        {
            if (isnull(value)) return None;

            if (value is string stringValue) return parseBool(stringValue);
            if (value is bool boolValue) return boolValue;
            return Try(() => Convert.ToBoolean(value)).ToOption();
        }

        static Option<decimal> TryCreateDecimal(object value)
        {
            if (isnull(value)) return None;

            if (value is string stringValue) return parseDecimal(stringValue);

            return Try(() => Convert.ToDecimal(value)).ToOption();
        }
    }
}