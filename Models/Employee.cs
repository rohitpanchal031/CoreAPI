using System;
using System.Collections.Generic;

namespace InsuranceCore.Models
{
    public partial class Employee
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public int? Managerid { get; set; }
        public int? Depid { get; set; }
        public int? Salary { get; set; }
        public DateTime? Dob { get; set; }
        public int Autoid { get; set; }
    }
}
