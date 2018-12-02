using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IPayslip
    {
        string Name { get; set; }
        string PayPeriod { get; set; }
        int GrossIncome { get; set; }
        int IncomeTax { get; set; }
        int NetIncome { get; set; }
        double Super { get; set; }
    }
}
