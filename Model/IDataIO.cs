using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Model
{
    public interface IDataIO
    {
        List<string> ReadFile(string fileName);

        IPayslip GeneratePayslip();
    }
}
