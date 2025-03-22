using ERCOT_API_dashboard.Server.Models.Interface;

namespace ERCOT_API_dashboard.Server.Models.WindForecast
{
    public class SystemWideHourlyRegionalRequest : IUrlParameters
    {
        private DateTime _dateTimeNotSet = DateTime.MinValue;
        private readonly string _datetime_format = "yyyy-MM-ddTHH:mm:ss";

        public DateTime From { get; set; }
        public DateTime To   { get; set; }

        public SystemWideHourlyRegionalRequest() 
        {
            From = _dateTimeNotSet;
            To   = _dateTimeNotSet;
        }
        
        public string PostedDateTimeFromQryParam
        {
            get
            {
                return From != _dateTimeNotSet ?
                    string.Format("postedDatetimeFrom={0}&", From.ToString(_datetime_format))
                    : 
                    string.Empty;
            }
        }

        public string PostedDateTimeToQryParam
        {
            get
            {
                return To != _dateTimeNotSet ?
                    string.Format("postedDatetimeTo={0}&", To.ToString(_datetime_format))
                    :
                    string.Empty;
            }
        }

        public string UrlParameters
        {
            get
            {
                // Note: hard coding page size to 10 for faster development, till all
                //       necessary parameters are implemented
                return string.Format("?{0}{1}", 
                    PostedDateTimeFromQryParam,
                    PostedDateTimeToQryParam);
            }
        }
    }
}
