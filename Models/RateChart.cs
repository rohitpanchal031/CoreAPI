using System;
using System.Collections.Generic;

namespace InsuranceCore.Models
{
    public partial class RateChart
    {
        public int RateChartId { get; set; }
        public string CoveragePlan { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public int? NetPrice { get; set; }
    }
}
