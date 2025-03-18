using ERCOT_API_dashboard.Server.Models.Interface;

namespace ERCOT_API_dashboard.Server.Models.WindForecast
{
    public class SystemWideHourlyRegionalRequest : IUrlParameters
    {
        private SystemWideHourlyRegionalRequest() { }
        public SystemWideHourlyRegionalRequest(DateTime from) 
        {
            From = from;
        }

        public DateTime From { get; private set; }
        
        public string PostedDateTimeFrom
        {
            get
            {
                return From.ToString("yyyy-MM-ddTHH:mm:ss");
            }
        }

        public string UrlParameters
        {
            get
            {
                return string.Format("?postedDatetimeFrom={0}", PostedDateTimeFrom);
            }
        }
    }
}
