using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IDataPreProcessor
    {
        List<IStaff> GenerateStaffList(List<string> input);
        Dictionary<string,string> SplitLineToFields(string input);
        bool CheckIfFieldNullOrEmpty(Dictionary<string,string> fields);
        IStaff GenerateStaffObject(Dictionary<string,string> fields);
    }
}
