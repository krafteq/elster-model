namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    class StringValidator
    {
        readonly int? minLength;
        readonly int? maxLength;
        readonly int? exactLength;

        public StringValidator(int? minLength = null, int? maxLength = null, int? exactLength = null)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
            this.exactLength = exactLength;
        }

        public static StringValidator Max(int value) =>
            new StringValidator(maxLength: value);

        public static StringValidator Exact(int value) =>
            new StringValidator(exactLength: value);

        public Either<Error, string> Validate(string value)
        {
            if (this.exactLength != null)
            {
                if (value.Length != this.exactLength.Value)
                    return new Error($"length must be {this.exactLength.Value}");
            }

            if (this.minLength != null)
            {
                if (value.Length < this.minLength.Value)
                    return new Error($"min length is {this.minLength.Value}");
            }

            if (this.maxLength != null)
            {
                if (value.Length > this.maxLength.Value)
                    return new Error($"max length is {this.maxLength.Value}");
            }

            return value;
        }
    }
}