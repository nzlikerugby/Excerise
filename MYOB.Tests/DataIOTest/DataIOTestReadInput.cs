using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using MyServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYOB.Tests
{
    public partial class DataIOTests
    {
        /*
        [TestMethod]
        public void Test_ReadInput()
        {
            var mock = new Mock<IDataIO>();
            mock.Setup(p => p.ReadInput()).Returns( new List<IStaff> { new Employee{ FirstName = "David", LastName = "Zhao", AnnualSalary = "60050", SuperRate = "10%", PayPeriod = "01 March-31March" } });
            IDataIO dataIO = new DataIO
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
        */
    }
}
