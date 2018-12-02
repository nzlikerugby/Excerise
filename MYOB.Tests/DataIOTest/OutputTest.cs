using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using MyDataIO;

namespace MYOB.Tests
{
    public partial class DataIOTests
    {
        
        [TestMethod]
        public void Test_Output_Normal_Input()
        {
            var payslip = new Payslip
            {
                Name = "David",
                PayPeriod = "01 March-31 March",
                GrossIncome = 60500,
                IncomeTax = 5004,
                NetIncome = 4082,
                Super = 450
            };

            Assert.AreEqual(true, DataIO.GetDataIO().Output(payslip,OUTPUTTO.CONSOLE));
        }

        /*
        [TestMethod]
        [ExpectedException(typeof(Exception), "SUPER RATE MUST BE GREATER THAN 0")]
        public void Test_Output_Super_When_Input_Less_Than_0()
        {
            double? grossIncome = 3000;
            string superRate = "-0.3";
            int actual = service.OutputSuper(grossIncome, superRate);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "SUPER RATE CANNOT BE NULL")]
        public void Test_Output_Super_When_Input_Is_Null()
        {
            double? grossIncome = 3000;
            string superRate = null;
            int actual = service.OutputSuper(grossIncome, superRate);
        }
        */
    }
}
