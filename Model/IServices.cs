using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// Interface
    /// </summary>
    public interface IServices
    {
        /// <summary>
        /// API to generate payslips
        /// </summary>
        /// <param name="staffs"></param>
        /// <returns></returns>
        List<IPayslip> GeneratePayslips(List<IStaff> staffs);
    }
}
