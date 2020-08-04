using System;
using System.Collections.Generic;

namespace InsuranceCore.Models
{
    public partial class CoveragePlan
    {
        public int PlanId { get; set; }
        public string Plan { get; set; }
        public DateTime? EligibilityDateFrom { get; set; }
        public DateTime? EligibilityDateTo { get; set; }
        public string EligibilityCountry { get; set; }
    }
}
