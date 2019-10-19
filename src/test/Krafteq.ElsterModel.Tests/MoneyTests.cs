namespace Krafteq.ElsterModel.Tests
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class MoneyTests
    {
        [Fact]
        public void ItShouldRoundUpValidValue()
        {
            Money.RoundUp(1.2545m).should_be_valid().Value.Should().Be(1.26m);
        }

        [Fact]
        public void ItShouldRoundDownValidValue()
        {
            Money.RoundDown(1.2545m).should_be_valid().Value.Should().Be(1.25m);
        }
        
        [Fact]
        public void ItShouldThrowExceptionWhenGivenValueIsTooBig()
        {
            Money.RoundUp(100m * 1000 * 1000 * 1000).should_fail();
        }
        
        [Fact]
        public void ItShouldCreateNegativeValue()
        {
            Money.RoundUp(-1).should_be_valid().Value.Should().Be(-1);
        }
    }
}