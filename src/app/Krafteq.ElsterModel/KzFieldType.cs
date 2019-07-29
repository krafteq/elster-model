namespace Krafteq.ElsterModel
{
    using System;
    using LanguageExt;

    using static LanguageExt.Prelude;

    public class KzFieldType : NewType<KzFieldType, string>
    {
        readonly Func<object, Either<Error, KzFieldValue>> valueFactory;

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

        KzFieldType(string value, Func<object, Either<Error, KzFieldValue>> valueFactory) : base(value)
        {
            this.valueFactory = valueFactory;
        }

        public Either<Error, KzFieldValue> CreateFieldValue(object value) => this.valueFactory(value);

        static Func<object, Either<Error, KzFieldValue>> DecimalValue<T>(
            Func<T, KzFieldValue> fieldValueFactory,
            Func<decimal, Either<Error, T>> intermediateFactory) =>
            DecimalValue(x => intermediateFactory(x).Map(fieldValueFactory));

        static Func<object, Either<Error, KzFieldValue>> DecimalValue(
            Func<decimal, Either<Error, KzFieldValue>> fieldValueFactory) =>
            value => CreateDecimal(value).Bind(fieldValueFactory);

        static Either<Error, KzFieldValue> BooleanValue(object value) =>
            CreateBoolean(value).Map(KzFieldValue.Boolean);

        static Either<Error, bool> CreateBoolean(object value) =>
            TryCreateBool(value).ToEither(() => new Error("invalid boolean"));

        static Either<Error, decimal> CreateDecimal(object value) =>
            TryCreateDecimal(value).ToEither(() => new Error("invalid decimal"));

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