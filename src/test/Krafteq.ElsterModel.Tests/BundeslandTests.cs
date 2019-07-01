namespace Krafteq.ElsterModel.Tests
{
    using FluentAssertions;
    using Xunit;
    using Xunit.Sdk;

    public class BundeslandTests
    {
        [Fact]
        public void ItShouldParseBW()
        {
            Bundesland.Parse("BW").ShouldBeSome().Should().Be(Bundesland.BadenWuerttemberg);
        }
 
        [Fact]
        public void ItShouldParseAllBundeslands()
        {
            var all = Bundesland.All;

            foreach (var bundesland in all)
            {
                Bundesland.Parse(bundesland.Value).ShouldBeSome().Should().Be(bundesland);
            }
        }

        [Fact]
        public void ItShouldReturnNoneInCaseOfInvalidCode()
        {
            Bundesland.Parse("DDT").ShouldBeNone();
        }

        [Fact]
        public void ItShouldBe16Bundeslands()
        {
            Bundesland.All.Count.Should().Be(16);
        }

        // samples are taken from elster documentation
        [Theory]
        [InlineData("BW", "66815/08156", "2866081508156")]
        [InlineData("BY", "198/815/08152", "9198081508152")]
        [InlineData("BY", "296/815/08153", "9296081508153")]
        [InlineData("BE", "97/815/08154", "1197081508154")]
        [InlineData("BR", "098/815/08157", "3098081508157")]
        [InlineData("HB", "97 123 01233", "2497012301233")]
        [InlineData("HH", "41/815/08154", "2241081508154")]
        [InlineData("HE", "053 815 08158", "2653081508158")]
        [InlineData("MV", "098/815/08157", "4098081508157")]
        [InlineData("NI", "88/815/08158", "2388081508158")]
        [InlineData("NW", "400/8150/8159", "5400081508159")]
        [InlineData("RP", "99/815/08152", "2799081508152")]
        [InlineData("SL", "096/815/08187", "1096081508187")]
        [InlineData("SN", "248/815/08156", "3248081508156")]
        [InlineData("ST", "198/815/08152", "3198081508152")]
        [InlineData("SH", "38/815/08154", "2138081508154")]
        [InlineData("TH", "198/815/08152", "4198081508152")]
        public void ItCreatesTaxNumbers(string bundesland, string input, string expected)
        {
            Bundesland.Parse(bundesland).AssertSome()
                .CreateTaxNumber(input).ShouldBeSome().Value.Should().Be(expected);

        }
    }
}