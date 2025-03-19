using System.Text.Json;

namespace ERCOT_API_dashboard.Server.Models.WindForecast
{
    public class SystemWideHourlyRegionalResponse
    {
        public SystemWideHourlyRegionalResponse()
        {
            _meta = new MetaData();
        }

        public MetaData _meta { get; set; }

        // TODO : need mapper to map this to list of object !!!!!
        public IList<IList<JsonElement>> data { get; set; }
    }

    // represents data in response's _meta field
    public class MetaData
    {
        public int totalRecords {  get; set; }
        public int pageSize { get; set; }
        public int totalPage { get; set; }
        public int currentPage { get; set; }
    }
}
