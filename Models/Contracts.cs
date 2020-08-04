using System;
using System.Collections.Generic;

namespace InsuranceCore.Models
{
    public partial class Contracts
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? SaleDate { get; set; }
        public string CoveragePlan { get; set; }
        public int? NetPrice { get; set; }
    }
}
