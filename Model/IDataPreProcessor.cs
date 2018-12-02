using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// Data process module interface
    /// </summary>
    public interface IDataPreProcessor
    {
        /// <summary>
        /// Generate list of staffs from list of string input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        List<IStaff> GenerateStaffList(List<string> input);
        /// <summary>
        /// Split a string to dictionary object
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Dictionary<string,string> SplitLineToFields(string input);
        /// <summary>
        /// Validate data fields
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        bool CheckIfFieldNullOrEmpty(Dictionary<string,string> fields);
        /// <summary>
        /// Generate a staff object from dictionary object
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        IStaff GenerateStaffObject(Dictionary<string,string> fields);
    }
}
