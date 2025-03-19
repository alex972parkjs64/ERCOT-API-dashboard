using ERCOT_API_dashboard.Server.Models.WindForecast;

namespace ERCOT_API_dashboard.UnitTests.WindForecast
{
    public class SystemWideHourlyRegionalRequestTests
    {
        [Fact]
        public void FromDateTimeFormatTest1()
        {
            var exampleRequest = new SystemWideHourlyRegionalRequest
            {
                From = new DateTime(2025, 3, 17, 3, 30, 45)
            };

            Assert.Equal("2025-03-17T03:30:45", exampleRequest.PostedDateTimeFrom);
        }

        [Fact]
        public void FromDateTimeFormatTest2()
        {
            var exampleRequest = new SystemWideHourlyRegionalRequest
            {
                From = new DateTime(2025, 10, 5, 22, 5, 7)
            };

            Assert.Equal("2025-10-05T22:05:07", exampleRequest.PostedDateTimeFrom);
        }
    }
}
