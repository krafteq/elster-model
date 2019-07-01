namespace Krafteq.ElsterModel.Tests
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class UnsignedMoneyTests
    {
        [Fact]
        public void ItShouldRoundUpValidValue()
        {
            UnsignedMoney.RoundUp(1.2545m).Value.Should().Be(1.26m);
        }
        
        [Fact]
        public void ItShouldRoundDownValidValue()
        {
            UnsignedMoney.RoundDown(1.2545m).Value.Should().Be(1.25m);
        }
        
        [Fact]
        public void ItShouldThrowExceptionWhenGivenValueIsTooBig()
        {
            Assert.Throws<InvalidOperationException>(() =>
                UnsignedMoney.RoundUp(100m * 1000 * 1000 * 1000));
        }
            
        [Fact]
        public void ItShouldNotCreateNegativeValue()
        {
            Assert.Throws<InvalidOperationException>(() =>
                UnsignedMoney.RoundUp(-1));
        }
    }
}