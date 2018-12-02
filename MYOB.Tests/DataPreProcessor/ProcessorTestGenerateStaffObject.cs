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
    public partial class DataPreProcessorTests
    {
        [TestMethod]
        public void Test_GenerateStaffObject_Normal_Input()
        {
            var dic = new Dictionary<string, string>
            {
                { "FirstName","David" },
                { "LastName","Rudd" },
                { "AnnualSalary","60050" },
                { "SuperRate","9%" },
                { "PayPeriod","01 March-31 March"}
            };
            var actual = processor.GenerateStaffObject(dic);
            Assert.AreEqual(actual.FirstName, "David");
            Assert.AreEqual(actual.LastName, "Rudd");
            Assert.AreEqual(actual.AnnualSalary, "60050");
            Assert.AreEqual(actual.SuperRate, "9%");
            Assert.AreEqual(actual.PayPeriod, "01 March-31 March");
        }

        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "INPUT FIELDS ARE NULL OR EMPTY")]
        public void Test_GenerateStaffObject_Input_Are_NUll()
        {
            Dictionary<string, string> dic = null;
            var actual = processor.GenerateStaffObject(dic);
            Assert.Fail("IF REACH HERE,THIS TEST FAILS");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "INPUT FIELDS ARE NULL OR EMPTY")]
        public void Test_GenerateStaffObject_Input_Are_Empty()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            var actual = processor.GenerateStaffObject(dic);
            Assert.Fail("IF REACH HERE,THIS TEST FAILS");
        }
    }
}
