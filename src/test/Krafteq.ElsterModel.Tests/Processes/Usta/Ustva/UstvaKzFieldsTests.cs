namespace Krafteq.ElsterModel.Tests.Processes.Usta.Ustva
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Krafteq.ElsterModel.Processes.Usta.Ustva;
    using Xunit;

    public class UstvaKzFieldsTests
    {
        [Fact]
        public void ItShouldReturnFormObject()
        {
            UstvaKzFields.Form.Should().NotBeNull();
        }

        [Fact]
        public void ItShouldFailOnCreatingEmptyReport()
        {
            UstvaKzFields.Create(new Dictionary<int, object>())
                .IsLeft.Should().BeTrue();
        }

        [Fact]
        public void ItShouldCreateReportWithJustKz83()
        {
            UstvaKzFields.Create(new Dictionary<int, object>
                {
                    [83] = 0m
                })
                .IsRight.Should().BeTrue();
        }

        [Fact]
        public void ItShouldNotCreateReportWhenSomeTaxFieldsAreGreaterThanAmount()
        {
            UstvaKzFields.Create(new Dictionary<int, object>
            {
                [47] = 10,
                [46] = 10,
                [83] = 10
            }).IsLeft.Should().BeTrue();
        }
        
        [Fact]
        public void ItShouldValidateKz83FieldIsCloseToEstimatedValue()
        {
            UstvaKzFields.Create(new Dictionary<int, object>
            {
                [47] = 20,
                [46] = 10,
                [83] = 10
            }).IsLeft.Should().BeTrue();
        }

        [Fact]
        public void ItShouldRoundValuesInTheRightDirection()
        {
            var kz = UstvaKzFields.Create(new Dictionary<int, object>
            {
                [66] = 9.9811, // should be rounded up 
                [81] = 100.9, // should be rounded down
                [86] = 200,
                [83] = 23.01 // 200 * 0.07 + 100 * 0.19 - 9.99
            }).AssertRight();
        }

        [Fact]
        public void ItShouldReturnErrorWhenKz47IsNotPresentedButKz46Is()
        {
            var result = UstvaKzFields.Create(new Dictionary<int, object>
            {
                [46] = 100,
                // 47 is missing, so it must be a validation error
                [83] = 0
            });

            result.IsLeft.Should().BeTrue();
        }
    }
}