using System.Collections.Generic;

namespace BLS_API_Example.Response
{
    public class Series
    {
        public string seriesID { get; set; }

        public IList<BLSData> Data { get; set; }
    }
}
