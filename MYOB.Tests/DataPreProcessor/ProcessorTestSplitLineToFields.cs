using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using MyDataIO;
using MyDataPreProcessor;
using MyServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace MYOB.Tests
{
    [TestClass]
    public partial class DataPreProcessorTests
    {
        [TestMethod]
        public void Test_SplitLineToFields_Normal_Input()
        {
            string input = "David,Rudd,60050,9%,01 March-31 March";
            var actual = processor.SplitLineToFields(input);
            Assert.AreEqual(actual["FirstName"], "David");
            Assert.AreEqual(actual["LastName"], "Rudd");
            Assert.AreEqual(actual["AnnualSalary"], "60050");
            Assert.AreEqual(actual["SuperRate"], "9%");
            Assert.AreEqual(actual["PayPeriod"], "01 March-31 March");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "INPUT FIELD MISSING")]
        public void Test_SplitLineToFields_Input_Field_Missing()
        {
            string input = "David,Rudd,60050,01 March-31 March";
            var actual = processor.SplitLineToFields(input);
            Assert.Fail("IF REACH HERE, THE TEST FAILS");
        }
    }
}
