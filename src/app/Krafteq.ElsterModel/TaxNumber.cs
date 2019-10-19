namespace Krafteq.ElsterModel
{
    using System;
    using System.Security;
    using LanguageExt;

    public class TaxNumber : NewType<TaxNumber, string>
    {
        public class Error
        {
            string inputMask;

            Error()
            {
            }

            public static Error InvalidInput(string expectedMask) => new Error {inputMask = expectedMask};

            public T Match<T>(Func<string, T> whenInvalidInput)
            {
                return whenInvalidInput(this.inputMask);
            }
        }
        
        static readonly Validator<StringError, string> Validator = Validators.All(
            StringValidators.ExactLength(13)
        );

        TaxNumber(string value) : base(value)
        {
        }

        public static Validation<Error, TaxNumber> FromLocalTaxNumber(
            Bundesland bundesland,
            string value
        )
        {
            if (bundesland == null) throw new ArgumentNullException(nameof(bundesland));
            if (value == null) throw new ArgumentNullException(nameof(value));

            var isValidInputMask = bundesland.taxNumberReplacer.IsValidInput(value);
            if (!isValidInputMask)
                return Error.InvalidInput(bundesland.taxNumberReplacer.inputMask);

            return new TaxNumber(bundesland.taxNumberReplacer.Replace(value));
        }

        public static Validation<StringError, TaxNumber> Create(string value) =>
            Validator(value).Map(x => new TaxNumber(x));
    }
}