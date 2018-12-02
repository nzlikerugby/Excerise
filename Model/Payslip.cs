using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Payslip:IPayslip
    {
        public string Name { get; set; }
        public string PayPeriod { get; set; }
        public int GrossIncome { get; set; }
        public int IncomeTax { get; set; }
        public int NetIncome { get; set; }
        public double Super { get; set; }
    }
}
