using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyDataIO
{
    public class OutToConsole : IOutTo
    {
        public bool OutputToDest(List<IPayslip> payslips)
        {
            if(payslips == null)
            {
                throw new Exception("PAYSLIP IS NULL");
            }
            foreach(var p in payslips)
            {
                Console.WriteLine($"{p.Name},{p.PayPeriod},{p.GrossIncome},{p.IncomeTax},{p.NetIncome},{p.Super}");
            }
            return true;
        }
    }

    public class OutToFile : IOutTo
    {
        public bool OutputToDest(List<IPayslip> ps)
        {
            var file = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "payslip","data","output.csv");
            StringBuilder sb = new StringBuilder();
            StringWriter strWriter = new StringWriter(sb);

            using (var fs = new FileStream(file,FileMode.OpenOrCreate))
            {
                var sw = new StreamWriter(fs);
                ps.ForEach(p =>
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

    public class OutToBoth : IOutTo
    {
        private static OutToFile outFile = new OutToFile();
        private static OutToConsole outConsole = new OutToConsole();
        public bool OutputToDest(List<IPayslip> payslips)
        {
            if (payslips == null)
            {
                throw new Exception("PAYSLIP IS NULL");
            }
            outFile.OutputToDest(payslips);
            outConsole.OutputToDest(payslips);
            return true;
        }
    }
}
