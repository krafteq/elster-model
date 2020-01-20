namespace Krafteq.ElsterModel.ValidationCore
{
    using System;
    using System.Text.RegularExpressions;
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

        public static StringValidator MatchRegex(string regexPattern)
        {
            var regex = new Regex(regexPattern, RegexOptions.Compiled);

            return v => Optional(v)
                .Filter(x => regex.IsMatch(x))
                .ToValidation(StringError.DoesNotMatchRegex(regexPattern));
        }
    }

    public class StringError
    {
        int? minLength;
        int? maxLength;
        bool digitsOnly;
        string part;
        string regexPattern;

        StringError()
        {
        }

        public static StringError MinLength(int minLength) =>
            new StringError {minLength = minLength};

        public static StringError MaxLength(int maxLength) =>
            new StringError {maxLength = maxLength};

        public static StringError DigitsOnly() => new StringError {digitsOnly = true};

        public static StringError MustNotContain(string part) => new StringError {part = part};

        public static StringError DoesNotMatchRegex(string pattern) => new StringError
        {
            regexPattern = pattern
        };

        public T Match<T>(
            Func<int, T> whenMinLength,
            Func<int, T> whenMaxLength,
            Func<Unit, T> whenDigitsOnly,
            Func<string, T> whenMustNotContainPart,
            Func<string, T> whenDoesNotMatchRegex,
            Func<StringError, T> whenOther)
        {
            if (this.digitsOnly) return whenDigitsOnly(unit);
            if (this.minLength != null) return whenMinLength(this.minLength.Value);
            if (this.maxLength != null) return whenMaxLength(this.maxLength.Value);
            if (this.part != null) return whenMustNotContainPart(this.part);
            if (this.regexPattern != null) return whenDoesNotMatchRegex(this.regexPattern);

            return whenOther(this);
        }

        public T Match<T>(
            Func<int, T> whenMinLength,
            Func<int, T> whenMaxLength,
            Func<Unit, T> whenDigitsOnly,
            Func<string, T> whenMustNotContainPart,
            Func<StringError, T> whenOther) =>
            this.Match(
                whenMinLength,
                whenMaxLength,
                whenDigitsOnly,
                whenMustNotContainPart,
                whenDoesNotMatchRegex: _ => whenOther(this),
                whenOther);
    }
}