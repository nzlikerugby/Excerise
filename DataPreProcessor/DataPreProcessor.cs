using Model;
using System;
using System.Collections.Generic;

namespace MyDataPreProcessor
{
    /// <summary>
    /// Input list of strings and output list of staffs
    /// This module is used after DataIO module
    /// and before Service module
    /// </summary>
    public class DataPreProcessor : IDataPreProcessor
    {
        private static DataPreProcessor processor;
        private DataPreProcessor()
        {
        }

        /// <summary>
        /// Ensure single instance of this class
        /// </summary>
        /// <returns></returns>
        public static IDataPreProcessor GetProcessor()
        {
            if (processor == null)
            {
                processor = new DataPreProcessor();
            }
            return processor;
        }

        /// <summary>
        /// Check if every field of a record is null or empty
        /// </summary>
        /// <param name="fields"></param>
        /// <returns>If no null and no empty file then return true</returns>
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

        /// <summary>
        /// Generate staff list from every record
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Generate a single staff object 
        /// </summary>
        /// <param name="fields"></param>
        /// <returns>A single staff</returns>
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
        
        /// <summary>
        /// Process and split string to dictionary object
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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
