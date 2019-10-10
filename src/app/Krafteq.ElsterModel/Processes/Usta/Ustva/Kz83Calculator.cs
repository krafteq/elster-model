namespace Krafteq.ElsterModel.Processes.Usta.Ustva
{
    using System;
    using LanguageExt;

    public class Kz83Calculator
    {
        readonly KzFieldSet fieldSet;

        public Kz83Calculator(KzFieldSet fieldSet)
        {
            this.fieldSet = fieldSet ?? throw new ArgumentNullException(nameof(fieldSet));
        }

        public Either<Error, Money> Calculate() => Money.RoundDown(
            this.V(81, 0.19m) +
            this.V(86, 0.07m) +
            this.V(36) +
            this.V(80) +
            this.V(96) +
            this.V(98) +
            this.V(89, 0.19m) +
            this.V(93, 0.07m) +
            this.V(85) +
            this.V(74) +
            this.V(53) +
            this.V(47) +
            this.V(65) +
            this.V(66, -1) +
            this.V(61, -1) +
            this.V(62, -1) +
            this.V(67, -1) +
            this.V(63, -1) +
            this.V(64, -1) +
            this.V(59, -1) +
            this.V(69) +
            this.V(39, -1)
        );

        decimal V(int number, decimal multiplier = 1m) =>
            this.fieldSet.GetValue(number)
                .Map(v => v.GetDecimalValue() * multiplier)
                .IfNone(0m);
    }
}