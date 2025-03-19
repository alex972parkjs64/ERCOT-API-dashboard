using ERCOT_API_dashboard.Server.Models.Interface;

namespace ERCOT_API_dashboard.Server.Models.WindForecast
{
    public class SystemWideHourlyRegionalRequest : IUrlParameters
    {
        public DateTime From { get; set; }
        //public DateTime To   { get; set; }

        private readonly string _datetime_format = "yyyy-MM-ddTHH:mm:ss";
        
        public string PostedDateTimeFrom
        {
            get
            {
                return From.ToString(_datetime_format);
            }
        }

        //public string PostedDateTimeTo
        //{
        //    get
        //    {
        //        return From.ToString(_datetime_format);
        //    }
        //}

        public string UrlParameters
        {
            get
            {
                // Note: hard coding page size to 10 for faster development, till all
                //       necessary parameters are implemented
                // TODO: will need method to generate query string depending on available valid params
                //       when implementing rest of available request parameters
                return string.Format("?postedDatetimeFrom={0}&size=10", PostedDateTimeFrom);
            }
        }
    }
}
