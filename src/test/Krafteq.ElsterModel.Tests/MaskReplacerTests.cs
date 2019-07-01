namespace Krafteq.ElsterModel.Tests
{
    using FluentAssertions;
    using Xunit;

    public class MaskReplacerTests
    {
        [Fact]
        public void ItShouldReplaceVariables()
        {
            var sut = new MaskReplacer("0FF BBB UUUUP", "26FF0BBBUUUUP");

            var result = sut.Replace("053 815 08158");

            result.Should().Be("2653081508158");
        }

        [Fact]
        public void ItShouldValidateInputAgainstInputMask()
        {
            var sut = new MaskReplacer("0FF BBB UUUUP", "26FF0BBBUUUUP");

            sut.IsValidInput("53 815 08158").Should().BeFalse();
        }
    }
}