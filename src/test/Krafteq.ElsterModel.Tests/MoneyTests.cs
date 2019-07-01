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
            Money.RoundUp(1.2545m).Value.Should().Be(1.26m);
        }
        
        [Fact]
        public void ItShouldRoundDownValidValue()
        {
            Money.RoundDown(1.2545m).Value.Should().Be(1.25m);
        }
        
        [Fact]
        public void ItShouldThrowExceptionWhenGivenValueIsTooBig()
        {
            Assert.Throws<InvalidOperationException>(() =>
                Money.RoundUp(100m * 1000 * 1000 * 1000));
        }
        
        [Fact]
        public void ItShouldCreateNegativeValue()
        {
            Money.RoundUp(-1).Value.Should().Be(-1);
        }
    }
}