using System.Text.Json;

namespace ERCOT_API_dashboard.Server.Models.WindForecast
{
    public class WindForecastData
    {
        public WindForecastData(IList<JsonElement> windForecastData)
        {
            // for now, assume windForecastData will always have 8 elements
            PostedDatetime = windForecastData[0].GetDateTime();
            DeliveryDate = DateOnly.FromDateTime(windForecastData[1].GetDateTime());
            HourEnding = windForecastData[2].GetInt32();
            Region = windForecastData[3].GetString();
            ForecastedWindPower = Math.Round(windForecastData[4].GetSingle(), 1);
            ForecastingModel = windForecastData[5].GetString();
            UsedByErcotSystemOperation = windForecastData[6].GetBoolean();
            ForecastAdjustedForDaylightSaving = windForecastData[7].GetBoolean();
        }

        public DateTime PostedDatetime { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public int HourEnding { get; set; }

        // ERCOT region which wind forecast applies
        // ex) COASTAL, NORTH, WEST, SYSTEM_TOTAL
        public string? Region { get; set; }

        // in MW
        public double ForecastedWindPower { get; set; }
        public string? ForecastingModel { get; set; }

        public bool UsedByErcotSystemOperation { get; set; }
        public bool ForecastAdjustedForDaylightSaving { get; set; }
    }
}
