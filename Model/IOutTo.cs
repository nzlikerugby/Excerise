using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOutTo
    {
        bool OutputToDest(List<IPayslip> payslips);
    }
}
