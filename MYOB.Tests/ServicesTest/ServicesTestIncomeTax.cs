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
        public void Test_Output_IncomeTax()
        {
            string input = "49000";
            int actual = service.OutputIncomeTax(input);
            Assert.AreEqual(((3572+(int)Math.Ceiling((double.Parse(input) - 37000)*0.325))/12), actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "SALARY CANNOT BE NULL")]
        public void Test_Output_IncomeTax_When_Input_Is_Null()
        {
            string input = null;
            int actual = service.OutputIncomeTax(input);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "SALARY MUST BE GREATER THAN 0")]
        public void Test_Output_IncomeTax_When_Input_Less_Than_0()
        {
            string salary = "-10000";
            int actual = service.OutputIncomeTax(salary);
            Assert.Fail();
        }
    }
}
