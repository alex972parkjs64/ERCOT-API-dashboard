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
                // Note: hard coding page size to 10 for faster development, till all
                //       necessary parameters are implemented
                return string.Format("?postedDatetimeFrom={0}&size=10", PostedDateTimeFrom);
            }
        }
    }
}
