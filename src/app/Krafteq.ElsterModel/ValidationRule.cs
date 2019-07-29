namespace Krafteq.ElsterModel
{
    using System;
    using LanguageExt;

    public class ValidationRule
    {
        bool required;
        int? lessThan;
        Func<KzFieldSet, int, Lst<Error>> custom;
        
        ValidationRule(){}
        public static ValidationRule Required() => new ValidationRule { required = true };
        public static ValidationRule LessThan(int fieldNumber) => new ValidationRule {lessThan = fieldNumber};
        public static ValidationRule Custom(Func<KzFieldSet, int, Lst<Error>> validateFunc) =>
            new ValidationRule {custom = validateFunc};

        public Lst<Error> Validate(KzFieldSet fieldSet, int fieldNumber)
        {
            if (this.required)
            {
                return fieldSet.GetValue(fieldNumber)
                    .Match(some => Lst<Error>.Empty, () => Prelude.List(new Error("required")));
            }

            if (this.lessThan != null)
            {
                var comparedValue = fieldSet.GetValue(this.lessThan.Value)
                    .Map(x => x.GetDecimalValue())
                    .IfNone(0);

                return Prelude.toList(fieldSet.GetValue(fieldNumber)
                    .Map(value => value.GetDecimalValue())
                    .Match(
                        value => value >= comparedValue && value != 0m
                            ? Prelude.Some(new Error($"less than {this.lessThan.Value}"))
                            : Prelude.None,
                        () => Prelude.None));
            }

            if (this.custom != null)
            {
                return this.custom(fieldSet, fieldNumber);
            }

            throw new InvalidOperationException();
        }
    }
}