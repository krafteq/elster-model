namespace Krafteq.ElsterModel.Tests.Common
{
    using Krafteq.ElsterModel.Common;
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
            var sut = new StringValidator(minLength: minLength);

            if (isValid)
                sut.Validate(input).should_be_right();
            else
                sut.Validate(input).should_be_left();
        }
        
        [Theory]
        [InlineData(3, "", true)]
        [InlineData(3, "A", true)]
        [InlineData(2, "AB", true)]
        [InlineData(1, "AB", false)]
        public void ItShouldValidateMaximumLength(int maxLength, string input, bool isValid)
        {
            var sut = new StringValidator(maxLength: maxLength);

            if (isValid)
                sut.Validate(input).should_be_right();
            else
                sut.Validate(input).should_be_left();
        }
        
        [Theory]
        [InlineData(3, "", false)]
        [InlineData(3, "A", false)]
        [InlineData(2, "AB", true)]
        [InlineData(1, "AB", false)]
        public void ItShouldValidateExactLength(int exactLength, string input, bool isValid)
        {
            var sut = new StringValidator(exactLength: exactLength);

            if (isValid)
                sut.Validate(input).should_be_right();
            else
                sut.Validate(input).should_be_left();
        }
    }
}