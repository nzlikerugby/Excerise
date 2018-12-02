using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using MyDataIO;
using System.Collections.Generic;

namespace MYOB.Tests
{
    public partial class DataIOTests
    {
        
        [TestMethod]
        public void Test_Output_Normal_Input()
        {
            var payslips = new List<IPayslip>
            {
                new Payslip
                {
                    Name = "David",
                    PayPeriod = "01 March-31 March",
                    GrossIncome = 60500,
                    IncomeTax = 5004,
                    NetIncome = 4082,
                    Super = 450
                }                
            };
            Assert.AreEqual(true, DataIO.GetDataIO().Output(payslips,OUTPUTTO.CONSOLE));
        }                
    }
}
