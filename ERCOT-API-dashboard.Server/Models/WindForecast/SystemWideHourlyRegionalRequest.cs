using ERCOT_API_dashboard.Server.Models.Interface;

using System.Reflection;

namespace ERCOT_API_dashboard.Server.Models.WindForecast
{
    public record SystemWideHourlyRegionalRequest : IUrlParameters
    {
        private readonly DateTime DATE_TIME_NOT_SET = DateTime.MinValue;
        private readonly int INT_NOT_SET = -1;
        private readonly string STR_NOT_SET = string.Empty;
        private readonly string _datetime_format = "yyyy-MM-ddTHH:mm:ss";

        public DateTime PostedFrom { get; init; }
        public DateTime PostedTo   { get; init; }
        
        [Sortable]
        public string Region { get; init; }

        [Sortable]
        public string Model { get; init; }

        public int Page { get; init; }
        public int Size { get; init; }

        // use this to validate Sort property later
        internal bool ValidSortField(string sortParam)
        {
            var sortableProps = typeof(SystemWideHourlyRegionalRequest)
                    .GetProperties()                    
                    .Where(p => p.GetCustomAttribute<SortableAttribute>() != null)
                    .Select(p => p.Name)
                    .ToArray();

            return sortableProps?.Contains(sortParam) ?? false;
        }

        public SystemWideHourlyRegionalRequest() 
        {
            PostedFrom = DATE_TIME_NOT_SET;
            PostedTo   = DATE_TIME_NOT_SET;
            Region = STR_NOT_SET;
            Model = STR_NOT_SET;
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

        public string RegionParam
        {
            get
            {
                return Region != STR_NOT_SET ? $"region={Region}&" : string.Empty;
            }
        }

        public string ModelParam
        {
            get
            {
                return Model != STR_NOT_SET ? $"model={Model}&" : string.Empty;
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
