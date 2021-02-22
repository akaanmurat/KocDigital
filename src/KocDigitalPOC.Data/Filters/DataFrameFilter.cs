using System;
using System.Collections.Generic;
using System.Text;

namespace KocDigitalPOC.Data.Filters
{
    public class DataFrameFilter
    {
        public Guid? Id { get; set; }
        public string LocationId { get; set; }
        public string Title { get; set; }
        public bool? Completed { get; set; }
    }
}
