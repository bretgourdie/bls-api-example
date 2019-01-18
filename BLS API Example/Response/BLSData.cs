using System.Collections.Generic;

namespace BLS_API_Example.Response
{
    public class BLSData
    {
        public int Year { get; set; }
        public string Period { get; set; }
        public string PeriodName { get; set; }
        public string Value { get; set; }
        public IList<FootNote> FootNotes { get; set; }
    }
}
