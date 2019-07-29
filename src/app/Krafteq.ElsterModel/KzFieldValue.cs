namespace Krafteq.ElsterModel
{
    using System;
    using System.Globalization;

    public class KzFieldValue
    {
        Money money;
        MoneyInt moneyInt;
        bool? boolean;
        UnsignedMoney unsignedMoney;

        KzFieldValue()
        {
        }

        public static KzFieldValue Boolean(bool value) => new KzFieldValue {boolean = value};

        public static KzFieldValue Money(Money value) => new KzFieldValue
            {money = value ?? throw new ArgumentNullException(nameof(value))};

        public static KzFieldValue MoneyInt(MoneyInt value) => new KzFieldValue
            {moneyInt = value ?? throw new ArgumentNullException(nameof(value))};

        public static KzFieldValue UnsignedMoney(UnsignedMoney value) => new KzFieldValue
            {unsignedMoney = value ?? throw new ArgumentNullException(nameof(value))};

        public T Match<T>(
            Func<bool, T> whenBoolean,
            Func<Money, T> whenMoney,
            Func<MoneyInt, T> whenMoneyInt,
            Func<UnsignedMoney, T> whenUnsignedMoney)
        {
            if (this.boolean != null)
                return whenBoolean(this.boolean.Value);

            if (this.moneyInt != null)
                return whenMoneyInt(this.moneyInt);

            if (this.money != null)
                return whenMoney(this.money);

            if (this.unsignedMoney != null)
                return whenUnsignedMoney(this.unsignedMoney);

            throw new InvalidOperationException();
        }

        internal string FormattedXmlValue() => this.Match(
            b => b ? "1" : "0",
            m => m.Value.ToString(CultureInfo.InvariantCulture),
            m => m.Value.ToString(CultureInfo.InvariantCulture),
            m => m.Value.ToString(CultureInfo.InvariantCulture));

        public decimal GetDecimalValue() => this.Match(
            b => throw new InvalidOperationException("Boolean value doesn't has decimal value"),
            m => m.Value,
            m => m.Value,
            m => m.Value);
    }
}