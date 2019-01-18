using System.Collections.Generic;

namespace BLS_API_Example.Response
{
    public class BLSResponse
    {
        public string Status { get; set; }
        public int ResponseTime { get; set; }
        public IList<string> Message { get; set; }
        public IList<ResultsSeries> Results { get; set; }
    }
}
