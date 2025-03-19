using System.Text.Json;

namespace ERCOT_API_dashboard.Server.Models.WindForecast
{
    public class WindForecastData
    {
        public WindForecastData(IList<JsonElement> windForecastData)
        { 
        }

        public DateTime PostedDatetime { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public int HourEnding { get; set; }

        // ERCOT region which wind forecast applies
        // ex) COASTAL, NORTH, WEST, SYSTEM_TOTAL
        public string? Region { get; set; }

        // in MW
        public float ForecastedWindPower { get; set; }
        public string? ForecastingModel { get; set; }

        public bool UsedByErcotSystemOperation { get; set; }
        public bool ForecastAdjustedForDaylightSaving { get; set; }
    }
}
