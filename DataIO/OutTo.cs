using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MyDataIO
{
    /// <summary>
    /// Factory which output to console
    /// </summary>
    public class OutToConsole : IOutTo
    {
        /// <summary>
        /// Output payslips to console
        /// </summary>
        /// <param name="payslips">Payslips need be output</param>
        /// <returns>If success return true</returns>
        public bool OutputToDest(List<IPayslip> payslips)
        {
            if(payslips == null)
            {
                throw new Exception("PAYSLIP IS NULL");
            }
            Console.WriteLine();
            foreach(var p in payslips)
            {
                Console.WriteLine($"{p.Name},{p.PayPeriod},{p.GrossIncome},{p.IncomeTax},{p.NetIncome},{p.Super}");
            }
            Console.WriteLine();
            return true;
        }
    }

    /// <summary>
    /// Factory which output to file
    /// </summary>
    public class OutToFile : IOutTo
    {
        /// <summary>
        /// Output payslips to file
        /// </summary>
        /// <param name="payslips">Payslips need be output</param>
        /// <returns>If success return true</returns>
        public bool OutputToDest(List<IPayslip> payslips)
        {
            if (payslips == null)
            {
                throw new Exception("PAYSLIP IS NULL");
            }

            var file = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "payslip","data","output.csv");
            StringBuilder sb = new StringBuilder();
            StringWriter strWriter = new StringWriter(sb);

            using (var fs = new FileStream(file,FileMode.OpenOrCreate))
            {
                if(fs.Length == 0)
                {
                    strWriter.WriteLine($"Name,PayPeriod,GrossIncome,IncomeTax,NetIncome,Super");
                }
                var sw = new StreamWriter(fs);
                payslips.ForEach(p =>
                {
                    strWriter.WriteLine($"{p.Name},{p.PayPeriod},{p.GrossIncome},{p.IncomeTax},{p.NetIncome},{p.Super}");
                });
                sw.Write(sb);
                sw.Close();
            }
            strWriter.Close();
            return true;
        }
    }

    /// <summary>
    /// Factory which output to both console and file
    /// </summary>
    public class OutToMany : IOutTo
    {
        /// <summary>
        /// for future extension use. For example output to databse
        /// </summary>
        private List<IOutTo> outTo;
        
        public OutToMany(List<IOutTo> outTo)
        {
            this.outTo = outTo;
        }
        
        /// <summary>
        /// Output payslips to console and file
        /// </summary>
        /// <param name="payslips">Payslips need be output</param>
        /// <returns>If success return true</returns>
        public bool OutputToDest(List<IPayslip> payslips)
        {
            if (payslips == null)
            {
                throw new Exception("PAYSLIP IS NULL");
            }
            // use Task will be better here
            outTo.ForEach(p => p.OutputToDest(payslips));
            return true;
        }
    }
}
