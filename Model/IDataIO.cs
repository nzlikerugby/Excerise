using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Model
{
    /// <summary>
    /// Data input and output interface
    /// </summary>
    public interface IDataIO
    {
        /// <summary>
        /// Input interface
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Read file to list of strings</returns>
        List<string> ReadFile(string fileName);

        /// <summary>
        /// Output interface
        /// </summary>
        /// <param name="payslips">List of payslips for output</param>
        /// <param name="outputTo">Output destination option</param>
        /// <returns>If success then return true</returns>
        bool Output(List<IPayslip> payslips,OUTPUTTO outputTo);
    }
}
