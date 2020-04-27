namespace Krafteq.ElsterModel
{
    using System;
    using LanguageExt;
    
    using static LanguageExt.Prelude;

    public class KzFieldValidationRule
    {
        bool required;
        int? lessThan;
        Func<KzFieldSet, int, Lst<KzFieldError>> custom;
        
        KzFieldValidationRule(){}
        public static KzFieldValidationRule Required() => new KzFieldValidationRule { required = true };
        public static KzFieldValidationRule LessThan(int fieldNumber) => new KzFieldValidationRule {lessThan = fieldNumber};
        public static KzFieldValidationRule Custom(Func<KzFieldSet, int, Lst<KzFieldError>> validateFunc) =>
            new KzFieldValidationRule {custom = validateFunc};

        public Lst<KzFieldError> Validate(KzFieldSet fieldSet, int fieldNumber)
        {
            if (this.required)
            {
                return fieldSet.GetValue(fieldNumber)
                    .Match(some => Lst<KzFieldError>.Empty, () => Prelude.List(KzFieldError.Required));
            }

            if (this.lessThan != null)
            {
                var comparedField = fieldSet.GetValue(this.lessThan.Value);
                var currentField = fieldSet.GetValue(fieldNumber);
                
                var comparedValue = comparedField
                    .Map(x => x.GetDecimalValue())
                    .IfNone(0);

                return toList(currentField
                    .Map(value => value.GetDecimalValue())
                    .Match(
                        value => value >= comparedValue && value != 0m
                            ? Some(KzFieldError.MustBeLessThanAnotherField(this.lessThan.Value))
                            : None,
                        () => comparedField.Match(
                            Some: _ => Some(KzFieldError.Required),
                            None: () => None
                        )));
            }

            if (this.custom != null)
            {
                return this.custom(fieldSet, fieldNumber);
            }

            throw new InvalidOperationException();
        }
    }
}