using Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyDataIO
{
    public class DataIO : IDataIO
    {
        private static IDataIO dataIO;
        
        private Stream stream;

        private DataIO() { }

        public static IDataIO GetDataIO()
        {
            if(dataIO == null)
            {
                dataIO = new DataIO();
            }
            return dataIO;
        }

        public List<string> ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new Exception("FILE DOES NOT EXIST");
            }
            stream = new FileStream(fileName, FileMode.Open);
            return StreamToStringLine();
        }

        public bool Output(List<IPayslip> payslips, OUTPUTTO output=OUTPUTTO.BOTH)
        {
            if (payslips == null)
            {
                throw new ArgumentNullException("PAYSLIP IS NULL");
            }
            IOutTo outputTo = SelectOutDest(output);
            outputTo.OutputToDest(payslips);
            return true;
        }

        private IOutTo SelectOutDest(OUTPUTTO output)
        {
            IOutTo outTo;
            switch (output)
            {
                case OUTPUTTO.CONSOLE: outTo = new OutToConsole();break;
                case OUTPUTTO.FILE: outTo = new OutToFile(); break;
                case OUTPUTTO.BOTH: outTo = new OutToBoth(); break;
                default: outTo = new OutToBoth();break;
            }
            return outTo;
        }

        private void OutputToConsole(IPayslip p)
        {
            if (p == null)
            {
                throw new ArgumentNullException("PAYSLIP IS NULL");
            }
            Console.WriteLine($"{p.Name},{p.PayPeriod},{p.GrossIncome},{p.IncomeTax},{p.NetIncome},{p.Super}");
        }

        private List<string> StreamToStringLine()
        {
            List<string> results = new List<string>();
            using(StreamReader sr = new StreamReader(stream))
            {
                var line = sr.ReadLine();
                // check if first line is valid data
                if(line.ToLower().Trim().Contains("firstname") || line.ToLower().Trim().Contains("first name"))
                {
                    line = sr.ReadLine();
                }
                while(line != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        results.Add(line);
                    }
                    line = sr.ReadLine();
                }
            }
            return results;
        }
    }
}
