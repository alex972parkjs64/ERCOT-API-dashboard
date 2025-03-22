using ERCOT_API_dashboard.Server.Models.Interface;

namespace ERCOT_API_dashboard.Server.Models.WindForecast
{
    public class SystemWideHourlyRegionalRequest : IUrlParameters
    {
        public readonly DateTime DATE_TIME_NOT_SET = DateTime.MinValue;
        public readonly int INT_NOT_SET = -1;
        private readonly string _datetime_format = "yyyy-MM-ddTHH:mm:ss";

        public DateTime From { get; set; }
        public DateTime To   { get; set; }
        public int Size { get; set; }

        public SystemWideHourlyRegionalRequest() 
        {
            From = DATE_TIME_NOT_SET;
            To   = DATE_TIME_NOT_SET;
            Size = INT_NOT_SET;
        }
        
        public string PostedDateTimeFromQryParam
        {
            get
            {
                return From != DATE_TIME_NOT_SET ?
                    string.Format("postedDatetimeFrom={0}&", From.ToString(_datetime_format))
                    : 
                    string.Empty;
            }
        }

        public string PostedDateTimeToQryParam
        {
            get
            {
                return To != DATE_TIME_NOT_SET ?
                    string.Format("postedDatetimeTo={0}&", To.ToString(_datetime_format))
                    :
                    string.Empty;
            }
        }

        public string SizeQryParam
        {
            get
            {
                return Size != INT_NOT_SET ? 
                    string.Format("size={0}&", Size)
                    :
                    string.Empty;
            }
        }

        public string UrlParameters
        {
            get
            {
                return string.Format("?{0}{1}{2}",
                    PostedDateTimeFromQryParam,
                    PostedDateTimeToQryParam,
                    SizeQryParam); // size should eventually be set to index 14 !
            }
        }
    }
}
