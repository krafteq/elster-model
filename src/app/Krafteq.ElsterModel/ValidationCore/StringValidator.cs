namespace Krafteq.ElsterModel
{
    using System;
    using LanguageExt;
    using static LanguageExt.Prelude;
    
    using StringValidator = Validator<StringError, string>;

    static class StringValidators
    {
        public static StringValidator MinLength(int length) =>
            v => Optional(v)
                .Filter(x => x.Length >= length)
                .ToValidation(StringError.MinLength(length));

        public static StringValidator MaxLength(int length) =>
            v => Optional(v)
                .Filter(x => x.Length <= length)
                .ToValidation(StringError.MaxLength(length));

        public static StringValidator ExactLength(int length) =>
            v => MinLength(length)(v) | MaxLength(length)(v);

        public static StringValidator DigitsOnly() =>
            v => Optional(v)
                .Filter(x => x.ForAll(char.IsDigit))
                .ToValidation(StringError.DigitsOnly());

        public static StringValidator MustNotContain(string part) =>
            v => Optional(v)
                .Filter(x => !x.Contains(part))
                .ToValidation(StringError.MustNotContain(part));
    }
    
    public class StringError
    {
        int? minLength;
        int? maxLength;
        bool digitsOnly;
        string part;

        StringError() {}

        public static StringError MinLength(int minLength) =>
            new StringError {minLength = minLength};

        public static StringError MaxLength(int maxLength) =>
            new StringError {maxLength = maxLength};

        public static StringError DigitsOnly() => new StringError {digitsOnly = true};

        public static StringError MustNotContain(string part) => new StringError {part = part};

        public T Match<T>(
            Func<int, T> whenMinLength, 
            Func<int, T> whenMaxLength, 
            Func<Unit, T> whenDigitsOnly,
            Func<string, T> whenMustNotContainPart,
            Func<StringError, T> whenOther)
        {
            if (this.digitsOnly) return whenDigitsOnly(unit);
            if (this.minLength != null) return whenMinLength(this.minLength.Value);
            if (this.maxLength != null) return whenMaxLength(this.maxLength.Value);
            if (this.part != null) return whenMustNotContainPart(this.part);

            return whenOther(this);
        }
    }
}