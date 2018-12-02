using Model;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
