using System.Collections.Generic;

namespace BLS_API_Example.Payload
{
    public class SeriesAndYearsPayload
    {
        public IList<string> seriesid { get; set; }
        public int startyear { get; set; }
        public int endyear { get; set; }
    }
}
