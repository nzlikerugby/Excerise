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
        public void Test_GenerateStaffList_Normal_Input()
        {
            var input = new List<string>
            {
                "David, Rudd, 60050, 10%,  01 March-31 March",
                "Tom,   Rudd, 50050,  9%,  01 July-31 July",
                "Steven,Rudd, 70050, 11%,  01 April-30 April"
            };
            var actual = processor.GenerateStaffList(input);
            Assert.AreEqual(3,actual.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "FIELD IS NULL OR EMPTY")]
        public void Test_GenerateStaffList_Wrong_Input()
        {
            var input = new List<string>
            {
                "David, Rudd, 60050, 10%,  01 March-31 March",
                "Tom,   Rudd, 50050,     , 01 July-31 July",
                "Steven,Rudd, 70050, 11% , 01 April-30 April"
            };
            var actual = processor.GenerateStaffList(input);
            Assert.Fail("IF REACH HERE,THIS TEST FAILS");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "INPUT FIELD MISSING")]
        public void Test_GenerateStaffList_Empty_Input()
        {
            var input = new List<string>
            {
                "David, Rudd, 60050, 10%,  01 March-31 March",
                "",
                "Steven,Rudd, 70050, 11% , 01 April-30 April"
            };
            var actual = processor.GenerateStaffList(input);
            Assert.Fail("IF REACH HERE,THIS TEST FAILS");
        }
    }
}
