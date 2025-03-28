using System.Text.Json;

namespace ERCOT_API_dashboard.Server.Models.WindForecast
{
    public record SystemWideHourlyRegionalResponse
    {
        public SystemWideHourlyRegionalResponse()
        {
            _meta = new MetaData();
        }

        public MetaData _meta { get; init; }
        
        public IList<IList<JsonElement>> data { get; init; }

        public IList<WindForecastData> WindForecastDataSet { get; init; } = new List<WindForecastData>();
        public void MapRawWindForecastData()
        {
            foreach (var item in data)
            {
                WindForecastDataSet.Add(new WindForecastData(item));
            }
        }
    }

    // represents data in response's _meta field
    public record struct MetaData
    {
        public int totalRecords {  get; init; }
        public int pageSize { get; init; }
        public int totalPage { get; init; }
        public int currentPage { get; init; }
    }
}
