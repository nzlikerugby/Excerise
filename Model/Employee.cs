using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Employee : IStaff
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AnnualSalary { get; set; }
        public string SuperRate { get; set; }
        public string PayPeriod { get; set; }
    }
}
