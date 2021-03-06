namespace Krafteq.ElsterModel.Tests
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class MoneyIntTests
    {
        [Fact]
        public void ItShouldRoundUpValidValue()
        {
            MoneyInt.RoundUp(1.25m).should_be_valid().Value.Should().Be(2);
        }
        
        [Fact]
        public void ItShouldRoundDownValidValue()
        {
            MoneyInt.RoundDown(1.25m).should_be_valid().Value.Should().Be(1);
        }
        
        [Fact]
        public void ItShouldThrowExceptionWhenGivenValueIsTooBig()
        {
            MoneyInt.RoundUp(10m * 1000 * 1000 * 1000 * 1000).should_fail();
        }
            
        [Fact]
        public void ItShouldCreateNegativeValue()
        {
            MoneyInt.RoundUp(-1).should_be_valid().Value.Should().Be(-1);
        }
    }
}