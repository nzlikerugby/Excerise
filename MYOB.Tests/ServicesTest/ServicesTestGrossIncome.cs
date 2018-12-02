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
        public void Test_Output_GrossIncome_Normal_Input()
        {
            string salary = "110.19";
            int actual = service.OutputGrossIncome(salary);
            Assert.AreEqual((int)Math.Floor( double.Parse(salary)/12), actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "SALARY MUST BE GREATER THAN 0")]
        public void Test_Output_GrossIncome_When_Input_Less_Than_0()
        {
            string salary = "-10000";
            int actual = service.OutputGrossIncome(salary);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "SALARY CANNOT BE NULL")]
        public void Test_Output_GrossIncome_When_Input_Is_Null()
        {
            string salary = null;
            int actual = service.OutputGrossIncome(salary);
            Assert.Fail();
        }

    }
}
