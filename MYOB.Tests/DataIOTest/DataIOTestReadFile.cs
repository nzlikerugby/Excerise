using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using MyDataIO;
using MyServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace MYOB.Tests
{
    [TestClass]
    public partial class DataIOTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "FILE DOES NOT EXIST")]
        public void Test_ReadFile_When_File_Not_Exists()
        {
            IDataIO dataIO = new DataIO();
            dataIO.ReadFile("FileDoesNotExist.csv");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "EMPTY FILE")]
        public void Test_ReadFile_When_File_Exists_But_No_Content()
        {
            IDataIO dataIO = new DataIO();
            var result = dataIO.ReadFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName,"payslip","data","hello.csv"));
        }

        [TestMethod]
        public void Test_ReadFile_When_File_Exists_With_Content()
        {
            IDataIO dataIO = new DataIO();
            var stream = dataIO.ReadFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "payslip", "data", "input.csv"));
            Assert.IsNotNull(stream);
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
