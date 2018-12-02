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
        public void Test_Output_Super_Normal_Input()
        {
            double? grossIncome = 3000;
            string superRate = "0.3";
            int actual = service.OutputSuper(grossIncome, superRate);
            Assert.AreEqual(900, actual);
        }

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
    }
}
