using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// Interface for generating payslip
    /// </summary>
    public interface IApp
    {
        /// <summary>
        /// Input a file then output payslips
        /// </summary>
        /// <param name="fileName"></param>
        void GeneratePayslip(string fileName);        
    }
}
