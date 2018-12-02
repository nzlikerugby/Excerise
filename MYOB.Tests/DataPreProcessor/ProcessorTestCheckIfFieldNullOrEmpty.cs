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
        public void Test_CheckIfFieldNullOrEmpty_Normal_Input()
        {
            var dic = new Dictionary<string, string>
            {
                { "FirstName","David" },
                { "LastName","Rudd" },
                { "AnnualSalary","60050" },
                { "SuperRate","9%" },
                { "PayPeriod","01 March-31 March"}
            };

            Assert.AreEqual(true, processor.CheckIfFieldNullOrEmpty(dic));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "FIELD IS NULL OR EMPTY")]
        public void Test_CheckIfFieldNullOrEmpty_Input_Contains_Null()
        {
            var dic = new Dictionary<string, string>
            {
                { "FirstName","David" },
                { "LastName","Rudd" },
                { "AnnualSalary","60050" },
                { "SuperRate",null },
                { "PayPeriod","01 March-31 March"}
            };
            var actual = processor.CheckIfFieldNullOrEmpty(dic);
            Assert.Fail("IF REACH HERE,TEST FAILS");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "FIELD IS NULL OR EMPTY")]
        public void Test_CheckIfFieldNullOrEmpty_Input_Contains_Empty()
        {
            var dic = new Dictionary<string, string>
            {
                { "FirstName","David" },
                { "LastName","Rudd" },
                { "AnnualSalary","60050" },
                { "SuperRate"," " },
                { "PayPeriod","01 March-31 March"}
            };
            var actual = processor.CheckIfFieldNullOrEmpty(dic);
            Assert.Fail("IF REACH HERE,TEST FAILS");
        }
    }
}
