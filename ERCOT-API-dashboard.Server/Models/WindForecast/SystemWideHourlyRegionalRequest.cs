namespace ERCOT_API_dashboard.Server.Models.WindForecast
{
    public class SystemWideHourlyRegionalRequest
    {
        private SystemWideHourlyRegionalRequest() { }
        public SystemWideHourlyRegionalRequest(DateTime from) 
        {
            From = from;
        }

        public DateTime From { get; private set; }

        // TODO: expected format is 2025-03-05T00:00:00
        public string PostedDateTimeFrom
        {
            get
            {
                return From.ToString("yyyy-MM-ddTHH:mm:ss");
            }
        }

    }
}
