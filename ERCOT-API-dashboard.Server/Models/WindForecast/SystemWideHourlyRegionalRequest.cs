using ERCOT_API_dashboard.Server.Models.Interface;

namespace ERCOT_API_dashboard.Server.Models.WindForecast
{
    public record SystemWideHourlyRegionalRequest : IUrlParameters
    {
        public readonly DateTime DATE_TIME_NOT_SET = DateTime.MinValue;
        public readonly int INT_NOT_SET = -1;
        private readonly string _datetime_format = "yyyy-MM-ddTHH:mm:ss";

        public DateTime PostedFrom { get; init; }
        public DateTime PostedTo   { get; init; }

        public int Page { get; init; }
        public int Size { get; init; }

        public SystemWideHourlyRegionalRequest() 
        {
            PostedFrom = DATE_TIME_NOT_SET;
            PostedTo   = DATE_TIME_NOT_SET;
            Size = INT_NOT_SET;
            Page = INT_NOT_SET;
        }
        
        public string PostedDateTimeFromQryParam
        {
            get
            {
                return PostedFrom != DATE_TIME_NOT_SET ?
                    $"postedDatetimeFrom={PostedFrom.ToString(_datetime_format)}&"
                    : 
                    string.Empty;
            }
        }

        public string PostedDateTimeToQryParam
        {
            get
            {
                return PostedTo != DATE_TIME_NOT_SET ?
                    $"postedDatetimeTo={PostedTo.ToString(_datetime_format)}&"
                    :
                    string.Empty;
            }
        }

        public string PageParam
        {
            get
            {
                return Page != INT_NOT_SET ? $"page={Page}&" : string.Empty;
            }
        }

        public string SizeQryParam
        {
            get
            {
                return Size != INT_NOT_SET ? 
                    $"size={Size}&"
                    :
                    string.Empty;
            }
        }        

        public string UrlParameters
        {
            get
            {
                return string.Format("?{0}{1}{2}{3}",
                    PostedDateTimeFromQryParam,
                    PostedDateTimeToQryParam,
                    PageParam,
                    SizeQryParam); // size should eventually be set to index 14 !
            }
        }
    }
}
