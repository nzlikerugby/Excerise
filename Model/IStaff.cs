using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// Staff interface. Staff might be 
    /// employee, manager, owner and so on
    /// </summary>
    public interface IStaff
    {
        /// <summary>
        /// First name of staff
        /// </summary>
        string FirstName { get; set; }
        /// <summary>
        /// Last name of staff
        /// </summary>
        string LastName { get; set; }
        /// <summary>
        /// Annual salary of staff
        /// </summary>
        string AnnualSalary { get; set; }
        /// <summary>
        /// Super rate of staff
        /// </summary>
        string SuperRate { get; set; }
        /// <summary>
        /// Payment period of staff
        /// </summary>
        string PayPeriod { get; set; }
    }
}
