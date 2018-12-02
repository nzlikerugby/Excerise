using Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyDataIO
{
    public class DataIO : IDataIO
    {
        /// <summary>
        /// DataIO field
        /// </summary>
        private static IDataIO dataIO;
        
        /// <summary>
        /// For read filestream use
        /// </summary>
        private Stream stream;

        /// <summary>
        /// Constructor for singleton
        /// </summary>
        private DataIO() { }

        /// <summary>
        /// Ensure only single instance
        /// </summary>
        /// <returns></returns>
        public static IDataIO GetDataIO()
        {
            if(dataIO == null)
            {
                dataIO = new DataIO();
            }
            return dataIO;
        }

        /// <summary>
        /// Read csv file and return string list
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public List<string> ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new Exception("FILE DOES NOT EXIST");
            }
            stream = new FileStream(fileName, FileMode.Open);
            return StreamToStringLine();
        }

        /// <summary>
        /// Output payslips to selected destination
        /// </summary>
        /// <param name="payslips">payslips for output</param>
        /// <param name="output">decide where to output</param>
        /// <returns></returns>
        public bool Output(List<IPayslip> payslips, OUTPUTTO output=OUTPUTTO.MANY)
        {
            if (payslips == null)
            {
                throw new ArgumentNullException("PAYSLIP IS NULL");
            }
            IOutTo outputTo = SelectOutDest(output);
            outputTo.OutputToDest(payslips);
            return true;
        }

        /// <summary>
        /// Factory method to return different output destination
        /// </summary>
        /// <param name="output">decide where to output</param>
        /// <returns>Specific output factory</returns>
        private IOutTo SelectOutDest(OUTPUTTO output)
        {
            IOutTo outTo;
            switch (output)
            {
                case OUTPUTTO.CONSOLE: outTo = new OutToConsole();break;
                case OUTPUTTO.FILE: outTo = new OutToFile(); break;
                case OUTPUTTO.MANY: outTo = new OutToMany(new List<IOutTo>{ new OutToConsole(),new OutToFile() }); break;
                default: outTo = new OutToMany(new List<IOutTo> { new OutToConsole(), new OutToFile() }); break;
            }
            return outTo;
        }

        /// <summary>
        /// Transform filestream to lines of string
        /// </summary>
        /// <returns>List of strings</returns>
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
