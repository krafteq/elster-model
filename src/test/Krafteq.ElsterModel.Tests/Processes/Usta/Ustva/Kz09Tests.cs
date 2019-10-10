namespace Krafteq.ElsterModel.Tests.Processes.Usta.Ustva
{
    using FluentAssertions;
    using Krafteq.ElsterModel.Processes.Usta.Ustva;
    using LanguageExt;
    using Xunit;
    
    using static LanguageExt.Prelude;

    public class Kz09Tests
    {
        [Fact]
        public void ItShouldFormatManufacturerOnlyCorrectly()
        {
            var sut = Kz09.Manufacturer(ManufacturerId.Create("12345").AssertRight());

            sut.Formatted.Should().Be("12345");
        }

        [Fact]
        public void ItShouldFormatOtherParts()
        {
            var manufacturerId = ManufacturerId.Create("12345").AssertRight();
            
            var sut = new Kz09(
                manufacturerId,
                Kz09PartialString.Create("Consultant Name").AssertRight(),
                None,
                None,
                None,
                Kz09PartialString.Create("Mandant Name").AssertRight()
            );

            sut.Formatted.Should().Be("12345*Consultant Name****Mandant Name");
        }
    }
}