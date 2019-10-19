namespace Krafteq.ElsterModel.Tests
{
    using Krafteq.ElsterModel.ValidationCore;
    using Xunit;

    public class StringValidatorTests
    {
        [Theory]
        [InlineData(1, "", false)]
        [InlineData(1, "A", true)]
        [InlineData(1, "AB", true)]
        [InlineData(3, "AB", false)]
        public void ItShouldValidateMinimumLength(int minLength, string input, bool isValid)
        {
            var sut = StringValidators.MinLength(minLength);

            if (isValid)
                sut(input).should_be_valid();
            else
                sut(input).should_fail();
        }

        [Theory]
        [InlineData(3, "", true)]
        [InlineData(3, "A", true)]
        [InlineData(2, "AB", true)]
        [InlineData(1, "AB", false)]
        public void ItShouldValidateMaximumLength(int maxLength, string input, bool isValid)
        {
            var sut = StringValidators.MaxLength(maxLength);

            if (isValid)
                sut(input).should_be_valid();
            else
                sut(input).should_fail();
        }

        [Theory]
        [InlineData(3, "", false)]
        [InlineData(3, "A", false)]
        [InlineData(2, "AB", true)]
        [InlineData(1, "AB", false)]
        public void ItShouldValidateExactLength(int exactLength, string input, bool isValid)
        {
            var sut = StringValidators.ExactLength(exactLength);

            if (isValid)
                sut(input).should_be_valid();
            else
                sut(input).should_fail();
        }
    }
}