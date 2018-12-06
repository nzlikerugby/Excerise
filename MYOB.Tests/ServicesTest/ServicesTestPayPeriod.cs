using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYOB.Tests
{
    public partial class ServicesTests
    {
        [TestMethod]
        public void Test_Output_Payperiod_Normal_Input()
        {
            string inputPayperiod = "01 March - 31 March";
            string payPeriod = service.OutputPayperiod(inputPayperiod);
            Assert.AreEqual("01 March-31 March", payPeriod);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "INPUT DATE CANNOT BE NULL OR EMPTY")]
        public void Test_Output_Payperiod_Input_Is_Null()
        {
            string inputPayperiod = null;
            string payPeriod = service.OutputPayperiod(inputPayperiod);
            Assert.AreEqual("01 March-31 March", payPeriod);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "INPUT DATE CANNOT BE NULL OR EMPTY")]
        public void Test_Output_Payperiod_Input_Is_Empty()
        {
            string inputPayperiod = "    ";
            string payPeriod = service.OutputPayperiod(inputPayperiod);
            Assert.AreEqual("01 March-31 March", payPeriod);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "INPUT DATE IN WRONG FORMAT")]
        public void Test_Output_Payperiod_Input_Is_Wrong_Format()
        {
            string inputPayperiod = "abc 09 de   ";
            string payPeriod = service.OutputPayperiod(inputPayperiod);
            Assert.AreEqual("01 March-31 March", payPeriod);
        }

    }
}
