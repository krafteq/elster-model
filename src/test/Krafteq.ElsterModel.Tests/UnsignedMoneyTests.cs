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
            UnsignedMoney.RoundUp(1.2545m).should_be_valid().Value.Should().Be(1.26m);
        }

        [Fact]
        public void ItShouldRoundDownValidValue()
        {
            UnsignedMoney.RoundDown(1.2545m).should_be_valid().Value.Should().Be(1.25m);
        }

        [Fact]
        public void ItShouldThrowExceptionWhenGivenValueIsTooBig()
        {
            UnsignedMoney.RoundUp(100m * 1000 * 1000 * 1000).should_fail();
        }

        [Fact]
        public void ItShouldNotCreateNegativeValue()
        {
            UnsignedMoney.RoundUp(-1).should_fail();
        }
    }
}