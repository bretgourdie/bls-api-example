using System.Collections.Generic;

namespace BLS_API_Example.Response
{
    public class BLSResponse<T> where T : class
    {
        public string Status { get; set; }
        public int ResponseTime { get; set; }
        public IList<string> Message { get; set; }
        public MultipleSeries Results { get; set; }
    }
}
