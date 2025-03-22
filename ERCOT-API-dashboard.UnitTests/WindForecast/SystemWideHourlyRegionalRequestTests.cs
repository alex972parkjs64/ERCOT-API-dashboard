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

            Assert.Equal("postedDatetimeFrom=2025-03-17T03:30:45&", exampleRequest.PostedDateTimeFromQryParam);
        }

        [Fact]
        public void FromDateTimeFormatTest2()
        {
            var exampleRequest = new SystemWideHourlyRegionalRequest
            {
                From = new DateTime(2025, 10, 5, 22, 5, 7)
            };

            Assert.Equal("postedDatetimeFrom=2025-10-05T22:05:07&", exampleRequest.PostedDateTimeFromQryParam);
        }

        [Fact]
        public void ToDateTimeFormatTest1()
        {
            var exampleRequest = new SystemWideHourlyRegionalRequest
            {
                To = new DateTime(2025, 3, 17, 3, 30, 45)
            };

            Assert.Equal("postedDatetimeTo=2025-03-17T03:30:45&", exampleRequest.PostedDateTimeToQryParam);
        }

        [Fact]
        public void ToDateTimeFormatTest2()
        {
            var exampleRequest = new SystemWideHourlyRegionalRequest
            {
                To = new DateTime(2025, 10, 5, 22, 5, 7)
            };

            Assert.Equal("postedDatetimeTo=2025-10-05T22:05:07&", exampleRequest.PostedDateTimeToQryParam);
        }

        [Fact]
        public void FromToDateTimeFormatTest1()
        {
            var exampleRequest = new SystemWideHourlyRegionalRequest
            {
                From = new DateTime(2025, 10, 5, 22, 5, 7),
                To = new DateTime(2025, 3, 17, 3, 30, 45)
            };

            Assert.Equal("?postedDatetimeFrom=2025-10-05T22:05:07&postedDatetimeTo=2025-03-17T03:30:45&", 
                exampleRequest.UrlParameters);
        }

        [Fact]
        public void FromToDateTimeFormatTest2()
        {
            var exampleRequest = new SystemWideHourlyRegionalRequest
            {
                From = new DateTime(2025, 3, 17, 3, 30, 45),
                To = new DateTime(2025, 10, 5, 22, 5, 7)
            };

            Assert.Equal("?postedDatetimeFrom=2025-03-17T03:30:45&postedDatetimeTo=2025-10-05T22:05:07&",
                exampleRequest.UrlParameters);
        }
    }
}
