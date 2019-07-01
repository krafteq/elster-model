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
            MoneyInt.RoundUp(1.25m).Value.Should().Be(2);
        }
        
        [Fact]
        public void ItShouldRoundDownValidValue()
        {
            MoneyInt.RoundDown(1.25m).Value.Should().Be(1);
        }
        
        [Fact]
        public void ItShouldThrowExceptionWhenGivenValueIsTooBig()
        {
            Assert.Throws<InvalidOperationException>(() =>
                MoneyInt.RoundUp(10m * 1000 * 1000 * 1000 * 1000));
        }
            
        [Fact]
        public void ItShouldCreateNegativeValue()
        {
            MoneyInt.RoundUp(-1).Value.Should().Be(-1);
        }
    }
}