using Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyDataIO
{
    public class DataIO : IDataIO
    {
        private Stream stream;
        public List<string> ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new Exception("FILE DOES NOT EXIST");
            }
            stream = new FileStream(fileName, FileMode.Open);
            return StreamToStringLine();
        }

        public IPayslip GeneratePayslip()
        {
            throw new NotImplementedException();
        }
           
        private List<string> StreamToStringLine()
        {
            List<string> results = new List<string>();
            using(StreamReader sr = new StreamReader(stream))
            {
                var line = sr.ReadLine();
                while(line != null)
                {
                    results.Add(line);
                }
            }
            return results;
        }
    }
}
