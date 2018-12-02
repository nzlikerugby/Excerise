using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// Employee details implementing Istaff
    /// </summary>
    public class Employee : IStaff
    {
        /// <summary>
        /// First name 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Annual salary
        /// </summary>
        public string AnnualSalary { get; set; }
        /// <summary>
        /// Super rate
        /// </summary>
        public string SuperRate { get; set; }
        /// <summary>
        /// Payment period
        /// </summary>
        public string PayPeriod { get; set; }
    }
}
