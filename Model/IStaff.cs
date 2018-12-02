using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IStaff
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string AnnualSalary { get; set; }
        string SuperRate { get; set; }
        string PayPeriod { get; set; }
    }
}
