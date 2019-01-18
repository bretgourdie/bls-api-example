using System.Collections.Generic;

namespace BLS_API_Example.Payload
{
    public class SeriesPayload
    {
        public IList<string> Series_Id { get; set; }
        public int? startYear { get; set; }
        public int? endYear { get; set; }
    }
}
