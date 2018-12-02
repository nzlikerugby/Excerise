using Model;
using System;
using System.Collections.Generic;

namespace MyDataPreProcessor
{
    public class DataPreProcessor : IDataPreProcessor
    {
        private static DataPreProcessor processor;
        private DataPreProcessor()
        {
        }

        public static IDataPreProcessor GetProcessor()
        {
            if (processor == null)
            {
                processor = new DataPreProcessor();
            }
            return processor;
        }


        public bool CheckIfFieldNullOrEmpty(Dictionary<string,string> fields)
        {
            foreach(var key in fields.Keys)
            {
                if (string.IsNullOrEmpty(fields[key]) || string.IsNullOrEmpty(fields[key].Trim()))
                {
                    throw new ArgumentNullException("FIELD IS NULL OR EMPTY");
                }                
            }
            return true;
        }

        public List<IStaff> GenerateStaffList(List<string> input)
        {
            if(input == null || input.Count == 0)
            {
                throw new ArgumentNullException("INPUT ARE NULL OR EMPTY");
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<IStaff> staff = new List<IStaff>();
            foreach(var item in input)
            {
                dic = SplitLineToFields(item);
                CheckIfFieldNullOrEmpty(dic);
                staff.Add(GenerateStaffObject(dic));
            }
            return staff;
        }

        public IStaff GenerateStaffObject(Dictionary<string,string> fields)
        {
            if(fields == null || fields.Count == 0)
            {
                throw new ArgumentNullException("INPUT FIELDS ARE NULL OR EMPTY");
            }
            IStaff staff = new Employee();
            foreach(var key in fields.Keys)
            {
                staff.GetType().GetProperty(key).SetValue(staff, fields[key]);
            }
            return staff;
        }
                
        public Dictionary<string,string> SplitLineToFields(string input)
        {
            string[] fields = input.Split(',');
            if(fields.Length != typeof(IStaff).GetProperties().Length)
            {
                throw new Exception("INPUT FIELD MISSING");
            }
            return new Dictionary<string, string>
            {
                { "FirstName",fields[0] },
                { "LastName",fields[1] },
                { "AnnualSalary",fields[2] },
                { "SuperRate",fields[3] },
                { "PayPeriod",fields[4] }
            };
        }
    }
}
