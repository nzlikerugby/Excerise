using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// Payslip interface
    /// </summary>
    public interface IPayslip
    {
        /// <summary>
        /// From first name and last name
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Period for payslip
        /// </summary>
        string PayPeriod { get; set; }
        /// <summary>
        /// Monthly income
        /// </summary>
        int GrossIncome { get; set; }
        /// <summary>
        /// Monthly income tax
        /// </summary>
        int IncomeTax { get; set; }
        /// <summary>
        /// Monthly net income
        /// </summary>
        int NetIncome { get; set; }
        /// <summary>
        /// Monthly super
        /// </summary>
        double Super { get; set; }
    }
}
