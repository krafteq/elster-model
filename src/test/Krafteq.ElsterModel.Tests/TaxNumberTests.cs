namespace Krafteq.ElsterModel.Tests
{
    using Xunit;

    public class TaxNumberTests
    {
        [Fact]
        public void ItShouldValidateUsingElsterRules()
        {
            TaxNumber.Create("4444012341234").should_be_valid();
            TaxNumber.Create("4444912341234").should_fail();
            TaxNumber.Create("abcs012341234").should_fail();
            TaxNumber.Create("444401234123b").should_fail();
        }
    }
}