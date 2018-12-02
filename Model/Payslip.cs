using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// Concrete class implementing IPayslip interface
    /// </summary>
    public class Payslip:IPayslip
    {
        /// <summary>
        /// From first name and last name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Period for payslip
        /// </summary>
        public string PayPeriod { get; set; }
        /// <summary>
        /// Monthly income
        /// </summary>
        public int GrossIncome { get; set; }
        /// <summary>
        /// Monthly income tax
        /// </summary>
        public int IncomeTax { get; set; }
        /// <summary>
        /// Monthly net income
        /// </summary>
        public int NetIncome { get; set; }
        /// <summary>
        /// Monthly super
        /// </summary>
        public double Super { get; set; }
    }
}
