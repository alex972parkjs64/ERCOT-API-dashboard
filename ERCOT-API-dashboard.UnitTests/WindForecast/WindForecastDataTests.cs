using ERCOT_API_dashboard.Server.Models.WindForecast;
using System.Text.Json;

namespace ERCOT_API_dashboard.UnitTests.WindForecast
{
    public class WindForecastDataTests
    {
        [Fact]
        public void WindForecastDataJsonMappingTest()
        {
            var rawWindForecastData = @"[
                ""2025-03-19T09:55:01"",
                ""2025-03-17"",
                10,
                ""SYSTEM_TOTAL"",
                22304.8,
                ""S"",
                true,
                false
            ]";

            var jsonDoc = JsonDocument.Parse(rawWindForecastData);
            var listOfJsonElements = new List<JsonElement>();
            
            foreach (var element in jsonDoc.RootElement.EnumerateArray())
            {
                listOfJsonElements.Add(element);
            }

            var windForecastData = new WindForecastData(listOfJsonElements);

            Assert.Equal(new DateTime(2025, 3, 19 ,9, 55, 1), 
                windForecastData.PostedDatetime);
            Assert.Equal(DateOnly.FromDateTime(new DateTime(2025, 3, 17, 0, 0, 0)), 
                windForecastData.DeliveryDate);
            Assert.Equal(10, windForecastData.HourEnding);
            Assert.Equal("SYSTEM_TOTAL", windForecastData.Region);
            Assert.Equal(Math.Round(22304.8, 1), windForecastData.ForecastedWindPower);
            Assert.Equal("S", windForecastData.ForecastingModel);
            Assert.True(windForecastData.UsedByErcotSystemOperation);
            Assert.False(windForecastData.ForecastAdjustedForDaylightSaving);
        }
    }
}
